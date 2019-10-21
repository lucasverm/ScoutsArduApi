using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenExportDTO
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public List<WinkelwagenItemExportDTO> Items { get; set; }
        public Boolean Betaald { get; set; }
        public GebruikerExportDTO Gebruiker { get; set; }

        public WinkelwagenExportDTO(Winkelwagen w)
        {
            this.Id = w.Id;
            this.Datum = w.Datum;
            this.Items = w.Items.Select(t => new WinkelwagenItemExportDTO(t)).ToList();
            this.Betaald = w.Betaald;
            this.Gebruiker = new GebruikerExportDTO(w.Gebruiker);
        }
    }


}
