using ScoutsArduAPI.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(200)]
        public string Voornaam { get; set; }
        [Required]
        [StringLength(250)]
        public string Achternaam { get; set; }
        [Required(ErrorMessage = "Please enter your password again")]
        [Compare("Password", ErrorMessage = "Password and passwordconfirmation must be the same")]
        public string PasswordConfirmation { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required(ErrorMessage = "Please enter a type")]
        public GebruikerType Type { get; set; }
    }
}
