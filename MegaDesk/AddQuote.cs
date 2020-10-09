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
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();

            this.widthUpDown.Minimum = Desk.MIN_WIDTH;
            this.widthUpDown.Maximum = Desk.MAX_WIDTH;

            this.depthUpDown.Minimum = Desk.MIN_DEPTH;
            this.depthUpDown.Maximum = Desk.MAX_DEPTH;

            this.drawersUpDown.Minimum = Desk.MIN_DRAWERS;
            this.drawersUpDown.Maximum = Desk.MAX_DRAWERS;


            // populate SurfaceMaterial combo box
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial))
                                                .Cast<DesktopMaterial>()
                                                .ToList();

            // set default to empty
            cmbSurfaceMaterial.DataSource = materials;

            cmbSurfaceMaterial.SelectedIndex = -1;

            // populate Delivery combo box
            List<Delivery> deliveryDate = Enum.GetValues(typeof(Delivery))
                                                .Cast<Delivery>()
                                                .ToList();

            // set default to empty
            cmbDelivery.DataSource = deliveryDate;

            cmbDelivery.SelectedIndex = -1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }



        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form mainMenu = (Form)this.Tag;
            mainMenu.Show();
        }

        private void btnAddQuote_Click(object sender, EventArgs e)
        {
            // create desk class
            Desk desk = new Desk();
            desk.Width = (int)this.widthUpDown.Value;
            desk.Depth = (int)this.depthUpDown.Value;
            desk.NumberOfDrawers = (int)this.drawersUpDown.Value;
            desk.SurfaceMaterial = (DesktopMaterial)this.cmbSurfaceMaterial.SelectedItem;

            // create desk quote class
            DeskQuote deskQuote = new DeskQuote();
            deskQuote.CustomerName = this.txtboxName.Text;
            deskQuote.Desk = desk;
            deskQuote.Delievery = (Delivery)this.cmbDelivery.SelectedItem;

            deskQuote.GetQuotePrice();

            //private void addQuoteToFile(DeskQuote) {

            //}
        }
    }
}
