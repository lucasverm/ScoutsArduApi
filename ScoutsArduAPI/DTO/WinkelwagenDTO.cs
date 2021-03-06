﻿using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenDTO
    {
        [Required]
        public List<WinkelwagenItemMtmDTO> Items { get; set; }
        public Boolean Betaald { get; set; }
        public String Datum { get; set; }
}
}
