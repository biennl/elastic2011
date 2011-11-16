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
    public partial class EchoServerForm : Form
    {
        Echo echo;
        public string adrCatalog = "127.0.0.1";

        public EchoServerForm()
        {
            InitializeComponent();
            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.btnRegister.Enabled = false;
            this.btnDeconnexion.Enabled = false;
            echo = new Echo(this.adrCatalog, Convert.ToInt32(this.tbPortEcoute.Text));
            echo.RegisterService(Convert.ToInt32(this.tbPortBox.Text));
            this.backgroundWorker.RunWorkerAsync();
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
            this.btnRegister.Enabled = true;
            this.btnDeconnexion.Enabled = false;
            this.backgroundWorker.CancelAsync();
        }

        private void MessageReceivedLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
