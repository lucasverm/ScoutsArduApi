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
        public int DatumDag { get; set; }
        public int DatumMaand { get; set; }
        public int DatumJaar { get; set; }
        public int DatumUur { get; set; }
        public int DatumMinuten { get; set; }

        public List<WinkelwagenItemMtmExportDTO> Items { get; set; }
        public Boolean Betaald { get; set; }
        public GebruikerExportDTO Gebruiker { get; set; }

        public WinkelwagenExportDTO(Winkelwagen w)
        {
            this.Id = w.Id;
            this.DatumDag = w.Datum.Day;
            this.DatumMaand = w.Datum.Month;
            this.DatumJaar = w.Datum.Year;
            this.DatumUur = w.Datum.Hour;
            this.DatumMinuten = w.Datum.Minute;
            this.Items = new List<WinkelwagenItemMtmExportDTO>();
            w.Items.ForEach(t =>
            {
                var dto = new WinkelwagenItemMtmExportDTO(t);
                this.Items.Add(dto);
            });
            this.Betaald = w.Betaald;
            this.Gebruiker = new GebruikerExportDTO(w.Gebruiker);
        }
    }


}
