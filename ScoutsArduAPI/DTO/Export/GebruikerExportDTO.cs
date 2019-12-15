using ScoutsArduAPI.Enum;
using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class GebruikerExportDTO
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string TelNr { get; set; }
        public string Foto { get; set; }
        public GebruikerType Type { get; set; }

        public GebruikerExportDTO(Gebruiker g)
        {
            this.Voornaam = g.Voornaam;
            this.Achternaam = g.Achternaam;
            this.Foto = g.Foto;
            this.Email = g.Email;
            this.Type = g.Type;
            this.TelNr = g.TelNr ?? "";
        }
    }
}
