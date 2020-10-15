using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk
{
    public partial class DisplayQuotes : Form
    {
        public DisplayQuotes()
        {
            InitializeComponent();
        }

        private void DisplayQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void DisplayQuote(DeskQuote deskQuote)
        {
            
        }

        private void DisplayQuotes_Load(object sender, EventArgs e, DeskQuote deskQuote)
        {
            DisplayName.Text = deskQuote.CustomerName;
            DisplayDepth.Text = deskQuote.Desk.Depth.ToString();
            DisplayWidth.Text = deskQuote.Desk.Width.ToString();
            DisplayDelivery.Text = deskQuote.Delievery.ToString();
            DisplayMaterial.Text = deskQuote.Desk.SurfaceMaterial.ToString();
            DisplayDrawer.Text = deskQuote.Desk.NumberOfDrawers.ToString();
            DisplayPrice.Text = deskQuote.QuotePrice.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
