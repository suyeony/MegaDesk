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
        public decimal QuotePrice { get; set; }

        // Properties
        private const decimal BASIC_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        private const decimal OAK_COST = 200.00M;
        private const decimal LAMINATE_COST = 100.00M;
        private const decimal PINE_COST = 50.00M;
        private const decimal ROSEWOOD_COST = 300.00M;
        private const decimal VENEER_COST = 125.00M;

        private const decimal RUSH_3DAYS = 60.00M;
        private const decimal RUSH_5DAYS = 40.00M;
        private const decimal RUSH_7DAYS = 30.00M;

        public decimal getRushOrderPrice()
        {
            decimal rushPrice = 0;
            
            if (this.Delievery == Delivery.Rush3days)
            {
                rushPrice = RUSH_3DAYS;
            }
            else if (this.Delievery == Delivery.Rush5days)
            {
                rushPrice = RUSH_5DAYS;
            }
            else if (this.Delievery == Delivery.Rush7days)
            {
                rushPrice = RUSH_7DAYS;
            }
            else
            {
                rushPrice = 0;
            }
            

            return rushPrice;
        }
        public decimal GetQuotePrice()
        {
            decimal cost = BASIC_DESK_PRICE;
            decimal DesktopSurfaceArea = this.Desk.Width * this.Desk.Depth;

            // desk surface area
            if (DesktopSurfaceArea > 1000)
            {
                cost += (DesktopSurfaceArea - 1000) * SURFACE_AREA_COST;
            }

            // surface material cost
            switch (this.Desk.SurfaceMaterial)
            {
                case DesktopMaterial.Oak:
                    cost += OAK_COST;
                    break;
                case DesktopMaterial.Laminate:
                    cost += LAMINATE_COST;
                    break;
                case DesktopMaterial.Pine:
                    cost += PINE_COST;
                    break;
                case DesktopMaterial.Rosewood:
                    cost += ROSEWOOD_COST;
                    break;
                case DesktopMaterial.Veneer:
                    cost += VENEER_COST;
                    break;
            }

            // Drawer cost
            cost += (Desk.NumberOfDrawers * 50);
            
            // Delivery cost
            cost += getRushOrderPrice();

            return cost;           
        }

    }

  



}
