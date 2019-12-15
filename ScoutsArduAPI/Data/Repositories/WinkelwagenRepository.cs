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
            _winkelwagen.Add(winkelwagen);
        }

        public void Delete(Winkelwagen winkelwagen)
        {    
            _winkelwagen.Remove(winkelwagen);
        }

        public IEnumerable<Winkelwagen> GetAll()
        {
            return _winkelwagen.Include(t => t.Gebruiker).Include(t => t.Items).ThenInclude(t => t.WinkelwagenItem).ToList();
        }

        public Winkelwagen GetBy(int id)
        {
            return _winkelwagen.Include(t => t.Gebruiker).Include(t => t.Items).ThenInclude(t => t.WinkelwagenItem).SingleOrDefault(t => t.Id == id);

        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Winkelwagen winkelwagen)
        {
            _winkelwagen.Update(winkelwagen);
            SaveChanges();
        }
    }
}
