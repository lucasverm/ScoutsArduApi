using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenItemDTO
    {
        public String Naam { get; set; }
        public float Prijs { get; set; }


        public WinkelwagenItem getWinkelwagenItem()
        {
            return new WinkelwagenItem
            {
                Naam = this.Naam,
                Prijs = this.Prijs
            };
        }

        public WinkelwagenItemDTO(WinkelwagenItem w)
        {
            this.Naam = w.Naam;
            this.Prijs = w.Prijs;
        }

        public WinkelwagenItemDTO()
        {

        }
    }
}
