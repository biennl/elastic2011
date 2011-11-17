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
            this.btnUnregister.Enabled = true;
            this.btnDisconnect.Enabled = false;
            echo = new Echo(this.adrCatalog, Convert.ToInt32(this.tbPortEcoute.Text));
            echo.RegisterService(Convert.ToInt32(this.tbPortBox.Text));
            this.backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            echo.EchoServiceListener();
            
        }

        
        private void btdeconnexion_Click(object sender, EventArgs e)
        {
            echo.UnregisterService("127.0.0.1", Convert.ToInt32(this.tbPortBox.Text));
            this.backgroundWorker.CancelAsync();
            this.Close();
        }

        
        private void btnUnregister_Click(object sender, EventArgs e)
        {
            echo.UnregisterService("127.0.0.1", Convert.ToInt32(this.tbPortBox.Text));
            this.btnUnregister.Enabled = false;
            this.btnRegister.Enabled = true;
        }
    }
}
