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
    public partial class Server : Form
    {

        NetworkManager networkManager;
        IListener listener;
        ISenderReceiver senderReceiver;
       

        ICatalog catalog;
       

        public Server()
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
            this.listener = this.networkManager.createListner("127.0.0.1", Convert.ToInt32(this.portBox.Text));
            this.connexionButton.Enabled = false;
            this.backgroundWorker1.RunWorkerAsync();
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
                   byte[] reqMsg  = senderReceiver.receive();

                   // addService(reqMsg);

                    byte[] respMsg = catalog.analyseMessage(reqMsg);
                    if (respMsg != null)
                    {
                        senderReceiver.send(respMsg);
                    }


                    //ServiceMessage msg =(ServiceMessage) encodMsg.Decode(reqMsg);
                    // setText(utf8Encoding.GetString(senderReceiver.receive()));
                    senderReceiver.send(utf8Encoding.GetBytes(this.messageReceivedLabel.Text)); 
                }

            }
        }

        //private delegate void setTextDelegateRichBox(byte[] bytes);

        private void addService(byte[] bytes)
        {

            Catalog acatalog = (Catalog)catalog;
            ServiceMessage msg = acatalog.decode(bytes);
            setText("\n SERVICE = " + msg.ListParams[1] + " ip: " + msg.ListParams[2] + " port :" +msg.ListParams[3]);
           
        }



        private delegate void setTextDelegate(string s);
        private void setText(string s)
        {
            if (messageReceivedLabel.InvokeRequired)
            {
                setTextDelegate sd = new setTextDelegate(setText);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                messageReceivedLabel.Text = s;
            }
            if (registeredServices.InvokeRequired)
            {
                setTextDelegate sd = new setTextDelegate(setText);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                registeredServices.Text = s;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          List<string> services = catalog.GetInfos("");
          foreach (string s in services)
          {
              registeredServices.Text = s+"\n";
          }
        }
    }
}
