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

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.registerButton.Enabled = false;
            this.btdeconnexion.Enabled = false;
            echo = new Echo(this.adrCatalog, Convert.ToInt32(this.portEcouteTextBox.Text));
            echo.RegisterService(Convert.ToInt32(this.portBox.Text));
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
            this.registerButton.Enabled = true;
            this.btdeconnexion.Enabled = false;
            this.backgroundWorker1.CancelAsync();
        }
    }
}
