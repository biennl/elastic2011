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
        IListener listener;
        ISenderReceiver senderReceiver;
        ICatalog catalog;

        const int SERVER_PORT = 50000;

        public ServerForm()
        {
            InitializeComponent();
            this.networkManager = new NetworkManager();
            catalog = new Catalog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                this.listener = this.networkManager.createListner("127.0.0.1", SERVER_PORT);
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


        private void timer_Tick(object sender, EventArgs e)
        {


            displayCatalog();

            if (this.listener != null)
            {
                if (this.listener.pending() == true)
                {
                    senderReceiver = this.listener.accept();
                }

                if ((this.senderReceiver != null) && (senderReceiver.available() != 0))
                {
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    byte[] reqMsg = senderReceiver.receive();


                    byte[] respMsg = catalog.analyseMessage(reqMsg);

                    if (respMsg != null)
                        senderReceiver.send(respMsg);

                }
            }
        }
    }
}
