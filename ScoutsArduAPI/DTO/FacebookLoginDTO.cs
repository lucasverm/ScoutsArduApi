using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class FacebookLoginDTO
    {
        public string Email { get; set; }

        public string Voornaam { get; set; }

        public string Achternaam { get; set; }
    }
}
