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
    public class WinkelwagenItemRepository : IWinkelwagenItemRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<WinkelwagenItem> _winkelwagenItem;

        public WinkelwagenItemRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;        
            _winkelwagenItem = dbContext.WinkelwagenItems;
        }

        public void Add(WinkelwagenItem winkelwagenItem)
        {
            _winkelwagenItem.Add(winkelwagenItem);
        }

        public void Delete(WinkelwagenItem winkelwagenItem)
        {
            _winkelwagenItem.Remove(winkelwagenItem);
        }

        public IEnumerable<WinkelwagenItem> GetAll()
        {
            return _winkelwagenItem.ToList().Select(t => {
                t.Aantal = 0;
                return t;
            }).ToList();
        }

        public WinkelwagenItem GetBy(int id)
        {
            return _winkelwagenItem.SingleOrDefault(r => r.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(WinkelwagenItem winkelwagenItem)
        {
            _context.Update(winkelwagenItem);
        }
    }
}
