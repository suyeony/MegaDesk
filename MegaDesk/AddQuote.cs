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
    }
}
