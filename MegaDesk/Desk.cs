using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk
{

    public enum DesktopMaterial 
    {
        Laminate,
        Oak,
        Rosewood,
        Veneer,
        Pine      
     }

    public class Desk
    {
        public static short MIN_WIDTH = 24;
        public static short MAX_WIDTH = 96;
        public static short MIN_DEPTH = 12;
        public static short MAX_DEPTH = 48;
        public static short MIN_DRAWERS = 0;
        public static short MAX_DRAWERS = 7;
        


        public int Width { get; set; }

        public int Depth { get; set; }

        public int NumberOfDrawers { get; set; }

        public DesktopMaterial SurfaceMaterial { get; set; }
    }
}
