using ScoutsArduAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.DTO
{
    public class WinkelwagenItemMtmExportDTO
    {
        public int Id { get; set; }
        public WinkelwagenItemExportDTO Item { get; set; }
        public int Aantal { get; set; }

        public WinkelwagenItemMtmExportDTO(MTMWinkelwagenWinkelwagenItem mtm)
        {
            this.Id = mtm.Id;
            this.Aantal = mtm.aantal;
            this.Item = new WinkelwagenItemExportDTO(mtm.WinkelwagenItem);

        }
    }


}
