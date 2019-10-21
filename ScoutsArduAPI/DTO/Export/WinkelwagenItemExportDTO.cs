using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenItemExportDTO
    {
        public int Id { get; set; }
        public float Prijs { get; set; }
        public int Aantal { get; set; }
        public String Naam { get; set; }

        public WinkelwagenItemExportDTO(WinkelwagenItem wi)
        {
            this.Id = wi.Id;
            this.Prijs = wi.Prijs;
            this.Aantal = wi.Aantal;
            this.Naam = wi.Naam;
        }
    }


}
