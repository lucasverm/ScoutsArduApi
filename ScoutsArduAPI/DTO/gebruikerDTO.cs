using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class GebruikerDTO
    {
       
        public String voornaam { get; set; }
        public String achternaam { get; set; }
        public String telnr { get; set; }
}
}
