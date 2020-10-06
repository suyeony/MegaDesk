using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{

    public enum Delivery
    {
        Rush3days, 
        Rush5days,
        Rush7days,
        NoRush14days
    }

    class DeskQuote
    {
        public Desk Desk { get; set; }
        public String CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public Delivery Delievery { get; set; }

        // Properties
        private const decimal BASIC_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;

        public decimal GetQuotePrice()
        {
            



        }

    }

  



}
