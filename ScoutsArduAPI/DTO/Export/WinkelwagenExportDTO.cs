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
        public String Datum { get; set; }
        public List<WinkelwagenItemMtmDTO> Items { get; set; }
        public Boolean Betaald { get; set; }
        public GebruikerExportDTO Gebruiker { get; set; }

        public WinkelwagenExportDTO(Winkelwagen w)
        {
            this.Id = w.Id;
            this.Datum = w.Datum;
            this.Items = new List<WinkelwagenItemMtmDTO>();
            w.Items.ForEach(t =>
            {
                var dto = new WinkelwagenItemMtmDTO(t);
                this.Items.Add(dto);
            });
            this.Betaald = w.Betaald;
            this.Gebruiker = new GebruikerExportDTO(w.Gebruiker);
        }
    }


}
