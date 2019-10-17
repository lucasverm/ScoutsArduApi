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
        private readonly IWinkelwagenItemRepository _winkewagenItemRepository;

        public WinkelwagenRepository(ApplicationDbContext dbContext, IWinkelwagenItemRepository WinkelwagenItemRepository)
        {
            _context = dbContext;
            _winkelwagen = dbContext.Winkelwagens;
            _winkewagenItemRepository = WinkelwagenItemRepository;
        }

        public void Add(Winkelwagen winkelwagen)
        {
            winkelwagen.Items.ForEach(w => _winkewagenItemRepository.Add(w));
            _winkewagenItemRepository.SaveChanges();
            _winkelwagen.Add(winkelwagen); 
        }

        public void Delete(Winkelwagen winkelwagen)
        {
            _winkelwagen.Remove(winkelwagen);
        }

        public IEnumerable<Winkelwagen> GetAll()
        {
            return _winkelwagen.ToList();
        }

        public Winkelwagen GetBy(int id)
        {
            return _winkelwagen.Include(t => t.Items).SingleOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Winkelwagen winkelwagen)
        {
            _context.Update(winkelwagen);
        }
    }
}
