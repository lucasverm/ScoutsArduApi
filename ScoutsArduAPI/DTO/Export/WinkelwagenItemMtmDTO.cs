using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenItemMtmDTO
    {
        public int Id { get; set; }
        public WinkelwagenItemExportDTO Item { get; set; }
        public int Aantal { get; set; }

        public WinkelwagenItemMtmDTO(MTMWinkelwagenWinkelwagenItem mtm)
        {
            this.Id = mtm.Id;
            this.Aantal = mtm.aantal;
            this.Item = new WinkelwagenItemExportDTO(mtm.WinkelwagenItem);

        }
    }


}
