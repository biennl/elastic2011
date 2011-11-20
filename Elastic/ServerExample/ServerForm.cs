using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworkLibrary;
using MessagesLibrary;
using CatalogService;


namespace ServerExample
{
    public partial class ServerForm : Form
    {

        NetworkManager networkManager;
        
        ICatalog catalog;

        const int SERVER_PORT = 50000;

        public ServerForm()
        {
            InitializeComponent();
            this.networkManager = new NetworkManager();
            catalog = new Catalog("127.0.0.1", SERVER_PORT);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                catalog.startService();
                this.lbConfig.Text += " IP=127.0.0.1" + " PORT=" + SERVER_PORT;

                btnStart.Text = "Stop";
            }
            else
            {
                btnStart.Text = "Start";
                lbConfig.Text = "CONFIGURATION:";
            }
        }

        private void displayCatalog()
        {
            tbRegisteredServices.Text = "";
            List<string> services = catalog.GetInfos("");
            for (int i = 0; i < services.Count(); i += 4)
            {
                tbRegisteredServices.Text += services[i + 0] +
                " " + services[i + 1] + " " + services[i + 2] + " " + services[i + 3] + " \n";
            }
        }
    }
}
