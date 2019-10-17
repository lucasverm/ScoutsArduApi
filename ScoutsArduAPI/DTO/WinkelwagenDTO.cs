using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenDTO
    {
        public List<WinkelwagenItemDTO> Items { get; set; }
        public Boolean Betaald { get; set; }
    }
}
