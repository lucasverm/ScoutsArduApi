using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public class WinkelwagenItem
    {
        public int Id { get; set; }
        public String Naam { get; set; }
        public float Prijs { get; set; }
        public int Aantal { get; set; }
        public List<Winkelwagen> Winkelwagens { get; set; }
    }
}
