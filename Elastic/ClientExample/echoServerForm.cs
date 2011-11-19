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
        private string echoIP = "127.0.0.1";

        const string CATALOG_ADDRESS = "127.0.0.1";
        const int CATALOG_PORT = 50000;

        public EchoServerForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (btnRegister.Text == "Register")
            {
                if (echo != null)
                {
                    echo.RegisterService(CATALOG_ADDRESS, CATALOG_PORT);
                    btnRegister.Text = "Unregister";
                    rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server is registered to Catalog server.\n";
                }
                else
                {
                    lbRegError.ForeColor = Color.Red;
                    lbRegError.Text = "You must start the service first!";
                }
            }
            else if (btnRegister.Text == "Unregister")
            {
                echo.UnregisterService(CATALOG_ADDRESS, CATALOG_PORT);
                btnRegister.Text = "Register";
                rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server is unregistered to Catalog server.\n";
            }
        }

        /*private void timer_Tick(object sender, EventArgs e)
        {
            if (echo != null)
                echo.EchoServiceListener();
        }
        */
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (this.tbPortEcoute.Text != "")
                {
                    echo = new Echo(this.echoIP, Convert.ToInt32(this.tbPortEcoute.Text));
                    btnStart.Text = "Stop";
                    lbServiceError.ForeColor = Color.Green;
                    lbServiceError.Text = "ECHO server: IP=127.0.0.1 Port=" + tbPortEcoute.Text;
                    lbRegError.Text = "";
                    rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server started.\n";
                }
                else
                {
                    lbServiceError.ForeColor = Color.Red;
                    lbServiceError.Text = "The listen port is not correct.";
                }
            }
            else if (btnStart.Text == "Stop")
            {
                echo.UnregisterService(CATALOG_ADDRESS, CATALOG_PORT);
                btnStart.Text = "Start";
                lbServiceError.Text = "";
                rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server stopped.\n";
            }
        }
    }
}
