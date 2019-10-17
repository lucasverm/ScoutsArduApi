using ScoutsArduAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public interface IWinkelwagenItemRepository
    {
        WinkelwagenItem GetBy(int id);
        IEnumerable<WinkelwagenItem> GetAll();
        void Add(WinkelwagenItem winkelwagenItem);
        void Delete(WinkelwagenItem winkelwagenItem);
        void Update(WinkelwagenItem winkelwagenItem);
        void SaveChanges();
    }
}
