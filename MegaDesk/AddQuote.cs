using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

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
            deskQuote.QuoteDate = DateTime.Now;
            deskQuote.Delievery = (Delivery)this.cmbDelivery.SelectedItem;
            deskQuote.QuotePrice = deskQuote.GetQuotePrice();

            try
            {
                // add quote to file
                addQuoteToFile(deskQuote);
                //addQuoteToFile(deskQuote);

            }
            catch (Exception err)
            {
                MessageBox.Show("There is an error when you create a quote. {0}",
                    err.InnerException.ToString());
            }
   
            var displayQuote = new DisplayQuotes();
            displayQuote.Tag = this;
            displayQuote.Show();
            //displayQuote.DisplayQuote(deskQuote);
            this.Hide();
            

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addQuoteToFile(DeskQuote deskQuote) {
           // create a quote file 
            var quotesFile = @"quote.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            // read json files first
            if (File.Exists(quotesFile))
            {             
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    string quotes = reader.ReadToEnd();

                    // check if quotes list is not empty
                    if (quotes.Length > 0)
                    {
                        // Deserializing desk quotes list
                        deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);
                    }
                }
            }

            // add a new quote
            deskQuotes.Add(deskQuote);

            // Save a quote to a json file
            saveQuote(deskQuotes);

        }

        private void saveQuote(List<DeskQuote> deskQuotes)
        {
            var quotesFile = @"quote.json";
            // write quotes in the json files

            string JSONResult = JsonConvert.SerializeObject(deskQuotes);
            using (StreamWriter writer = new StreamWriter(quotesFile))
            {
                writer.WriteLine(JSONResult.ToString());
                writer.Close();
            }
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {

        }
    }
}

