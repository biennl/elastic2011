using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CatalogService;


namespace ServerExample
{
    
    /// <summary>
    /// classe partiel qui represente l'ihm du catalogue
    /// delegue toutes les fonctions au service catalgoue instancier
    /// </summary>
    public partial class ServerForm : Form
    {

        ICatalog catalog;
        //port par defaut 5000 
        const int SERVER_PORT = 50000;

        public ServerForm()
        {
            InitializeComponent();
            catalog = new Catalog("127.0.0.1", SERVER_PORT);
        }

        /// <summary>
        /// méthode qui démmarre le service 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                catalog.stopService();
            }
        }

        //affichage de la liste des services enregistrer
        /// <summary>
        /// fonction qui affiche a intervalle régulier
        /// la liste des serveurs qui sont enregistrer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerDisplay_Tick(object sender, EventArgs e)
        {
            if (catalog !=null)
            {
                string res = catalog.displayCatalog();
                if(res!=null)
                    tbRegisteredServices.Text = res;
            }
             
        }
    }
}
