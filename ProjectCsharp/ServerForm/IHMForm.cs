using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketLibrary;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerForm
{
    public partial class IHMForm : Form
    {
        private IServer server;

        const int PORT = 50000;
        public IHMForm()
        {
            InitializeComponent();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                server = Utils.CreateServer(PORT);
                server.subscribe(ServerEventFunc);
                

                if (!server.start())
                {
                    MessageBox.Show("Problème de démarrage du serveur au port spécifié.", "Attention", MessageBoxButtons.OK);
                    return;
                }
                btnStart.Text = "Stop";
            }
            else if (btnStart.Text == "Stop")
            {
                if (server != null)
                {
                    server.stop();
                    server.unsubscribe();
                }
                btnStart.Text = "Start";
            }
        }

        public void ServerEventFunc(object sender, ServerEventArgs e)
        {
            Image img = byteArrayToImage(e.Msg);
            //Thread.Sleep(1000);
            setImage(img);
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            Image returnImage = null;
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                //BinaryFormatter fomatter = new BinaryFormatter();
                //returnImage = (Image)fomatter.Deserialize(ms);
                returnImage = Image.FromStream(ms);
                ms.Close();
            }
            return returnImage;
        }

        #region DELEGATE FUNCTION
        private delegate void DisplayImageDelegate(Image img);

        private void setImage(Image img)
        {
            if (pictureBox.InvokeRequired)
            {
                DisplayImageDelegate d = setImage;
                pictureBox.Invoke(d, img);
            }
            else
            {
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = img;
            }
        }
        #endregion
    }
}
