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
using CatalogService;

namespace ClientExample
{
    /// <summary>
    ///  classe qui represente l'IHM du service echo
    ///  cette classe delegue au service toutes les operations
    ///  demandées par l'utilisateur
    /// </summary>
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

        /// <summary>
        /// fonction qui est appelée lors d'un click 
        /// sur le bouton register. Declenche l'enregistrement 
        /// du service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerButton_Click(object sender, EventArgs e)
        {
            if (btnRegister.Text == "Register")
            {
                if (echo != null)
                {
                    echo.Register(CATALOG_ADDRESS, CATALOG_PORT);
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
                echo.Unregister(CATALOG_ADDRESS, CATALOG_PORT);
                btnRegister.Text = "Register";
                rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server is unregistered to Catalog server.\n";
            }
        }

        /// <summary>
        /// fonction qui affiche les message recus par les utilisateurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (echo != null && echo.History != "")
            {
                rtbLog.Text += echo.History;
                echo.History = "";
            }
        }

        /// <summary>
        /// methode appelée lors d'un click sur le bouton start 
        /// provoque le demarrage du service aps son enregistrement
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (this.tbPortEcoute.Text != "")
                {
                    if (echo == null)
                        echo = new Echo(this.echoIP, Convert.ToInt32(this.tbPortEcoute.Text));
                    echo.startService();
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
                //echo.UnregisterService(CATALOG_ADDRESS, CATALOG_PORT);
                echo.stopService();
                btnStart.Text = "Start";
                lbServiceError.Text = "";
                rtbLog.Text += DateTime.Now.ToShortDateString() + " ->Echo server stopped.\n";
            }
        }


    }
}
