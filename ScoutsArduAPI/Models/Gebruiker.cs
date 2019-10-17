using Microsoft.AspNetCore.Identity;
using ScoutsArduAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public class Gebruiker : IdentityUser
    {

        private string _voornaam;
        private string _achternaam;
        private string _foto;
        private string _email;
        private GebruikerType _gebruikerType;


        public string Voornaam {
            get {
                return _voornaam;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een gebruiker moet een voornaam hebben");
                _voornaam = value;
            }
        }

        public string Achternaam {
            get {
                return _achternaam;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een gebruiker moet een achternaam hebben");
                _achternaam = value;
            }
        }


        public override string Email {
            get {
                return _email;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een gebruiker moet een email hebben");
                else if (!Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    throw new ArgumentException("Ongeldig email formaat");
                _email = value;
            }
        }
        public string Foto {
            get {
                return _foto;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een gebruiker moet een foto hebben");
                _foto = value;
            }
        }

        public GebruikerType Type {
            get { return _gebruikerType; }
            set {
                if (false/*value == GebruikerType.Undefined*/)
                {
                    throw new ArgumentException("Selecteer het soort gebruiker");
                }
                else
                {
                    _gebruikerType = value;
                }
            }
        }

        public List<Winkelwagen> Winkelwagens { get; set; }

        public Gebruiker()
        {

        }

        public Gebruiker(string voornaam, string achternaam, string email, string foto, GebruikerType type) : this()
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Type = type;
            Foto = foto;
            UserName = email;
        }

    }
}
