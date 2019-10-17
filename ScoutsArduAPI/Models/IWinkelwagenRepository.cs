using ScoutsArduAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public interface IWinkelwagenRepository
    {
        Winkelwagen GetBy(int id);
        IEnumerable<Winkelwagen> GetAll();
        void Add(Winkelwagen winkelwagen);
        void Delete(Winkelwagen winkelwagen);
        void Update(Winkelwagen winkelwagen);
        void SaveChanges();
    }
}
