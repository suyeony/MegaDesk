using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{

    public enum Delivery
    {
        three, 
        five,
        seven,
        fourteen
    }

    class DeskQuote
    {
        public String CustomerName { get; set; }

        public Delivery Delievery { get; set; }
    }
}
