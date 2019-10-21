using Microsoft.EntityFrameworkCore;
using ScoutsArduAPI.Data;
using ScoutsArduAPI.Enum;
using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolveniershofBackend.Data.Repositories
{
    public class WinkelwagenRepository : IWinkelwagenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Winkelwagen> _winkelwagen;
        private readonly DbSet<MTMWinkelwagenWinkelwagenItem> _mtm;

        public WinkelwagenRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _winkelwagen = dbContext.Winkelwagens;
            _mtm = dbContext.MTMWinkelwagenWinkelwagenItems;
        }

        public void Add(Winkelwagen winkelwagen)
        {
            winkelwagen.Items.ForEach(wi =>
            {
                _mtm.Add(new MTMWinkelwagenWinkelwagenItem(winkelwagen, wi));
            });
            _winkelwagen.Add(winkelwagen);
        }

        public void Delete(Winkelwagen winkelwagen)
        {
            //alle mtm's verwijderen
            _mtm.Where(t => t.Winkelwagen == winkelwagen).ToList().ForEach(rel => _mtm.Remove(rel));
            _winkelwagen.Remove(winkelwagen);
        }

        public IEnumerable<Winkelwagen> GetAll()
        {
            List<Winkelwagen> alleWinkelwagens = _winkelwagen.ToList();
            alleWinkelwagens.ForEach(w =>
            {
                w.Items = new List<WinkelwagenItem>();
                _mtm.Where(k => k.Winkelwagen == w).Include(l => l.Winkelwagen).Include(l => l.WinkelwagenItem).ToList().ForEach(t =>
                {
                    w.Items.Add(t.WinkelwagenItem);
                });
            });
            return alleWinkelwagens;
        }

        public Winkelwagen GetBy(int id)
        {
            Winkelwagen w = _winkelwagen.SingleOrDefault(t => t.Id == id);
            if (w == null)
            {
                return null;
            }
            w.Items = new List<WinkelwagenItem>();
            _mtm.Where(a => a.Winkelwagen == w).Include(i => i.Winkelwagen).Include(p => p.WinkelwagenItem).ToList().ForEach(t =>
            {
                //veranderd
                w.Items.Add(t.WinkelwagenItem);
            });

            return w;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Winkelwagen winkelwagen)
        {
            //verwijder alle mtm's
            _mtm.Where(t => t.Winkelwagen == winkelwagen).ToList().ForEach(mtm => _mtm.Remove(mtm));

            //alle mtm's van deze ww opnieuw toevoegen
            winkelwagen.Items.ForEach(wi =>
            {
                _mtm.Add(new MTMWinkelwagenWinkelwagenItem(winkelwagen, wi));
            });
            _winkelwagen.Update(winkelwagen);
            SaveChanges();
            _context.Update(winkelwagen);
        }
    }
}
