﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public class Winkelwagen
    {
        public int Id { get; set; }
        public List<WinkelwagenItem> Items { get; set; }
        public Boolean Betaald { get; set; }
        public String Datum { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public Winkelwagen()
        {

        }

        public Winkelwagen(Gebruiker g)
        {
            this.Gebruiker = g;
        }
    }
}
