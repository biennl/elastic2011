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
using EncodingLibrary;
using EchoService;

namespace ClientExample
{
    public partial class echoServer : Form
    {
        Echo echo;
        public string adrCatalog = "127.0.0.1";

        public echoServer()
        {
            InitializeComponent();
            
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            this.connexionButton.Enabled = false;
            this.btdeconnexion.Enabled = true;
            echo = new Echo(this.adrCatalog, Convert.ToInt32(this.portBox.Text));
            echo.RegisterService();
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            echo.EchoServiceListener();
            
        }

        //modify IHM label
        private delegate void setTextDelegate(string s);
        private void setText(string s)
        {
            if (MessageReceivedLabel.InvokeRequired)
            {
                setTextDelegate sd = new setTextDelegate(setText);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                MessageReceivedLabel.Text = s;
            }
        }

        private void btdeconnexion_Click(object sender, EventArgs e)
        {
            echo.UnregisterService();
            this.connexionButton.Enabled = true;
            this.btdeconnexion.Enabled = false;
        }
    }
}
