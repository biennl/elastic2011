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


        public ServerForm()
        {
            InitializeComponent();
            this.networkManager = new NetworkManager();
            catalog = new Catalog();
        }

        private void portBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            this.listener = this.networkManager.createListner("127.0.0.1", Convert.ToInt32(this.tbPort.Text));
            this.btnStart.Enabled = false;
            this.backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
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

        
        
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            tbRegisteredServices.Text = "";
            List<string> services = catalog.GetInfos("");
            int j = 0;
            for (int i = 0; i < services.Count(); i += 4)
            {
                tbRegisteredServices.Text += services[i + 0] +
                " " + services[i + 1] + " " + services[i + 2] + " " + services[i + 3] + " \n";
            }
        }
    }
}
