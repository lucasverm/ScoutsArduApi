using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenItemMtmDTO
    {
        [Required]
        public WinkelwagenItemDTO item { get; set; }
        public int Aantal { get; set; }
       
    }
}
