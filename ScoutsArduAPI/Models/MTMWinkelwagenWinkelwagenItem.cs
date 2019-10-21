using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsArduAPI.Models
{
    public class MTMWinkelwagenWinkelwagenItem
    {
        public int Id { get; set; }

        public Winkelwagen Winkelwagen { get; set; }

        public WinkelwagenItem WinkelwagenItem { get; set; }

        public int aantal { get; set; }

        public MTMWinkelwagenWinkelwagenItem()
        {

        }

        public MTMWinkelwagenWinkelwagenItem(Winkelwagen w, WinkelwagenItem wi)
        {
            this.Winkelwagen = w;
            this.WinkelwagenItem = wi;
        }
    }
}
