using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClientIHM
{
    public partial class IHMForm : Form
    {
        private SocketLibrary.IClient client;
        private string file;

        const string IP_ADDRESS = "127.0.0.1";
        const int PORT = 50000;
        public IHMForm()
        {
            InitializeComponent();
        }

        //private void btnConnect_Click(object sender, EventArgs e)
        //{
        //    if (btnConnect.Text == "Connect")
        //    {
        //        client = Utils.CreateClient(IP_ADDRESS, PORT);
        //        if (!client.connect())
        //        {
        //            MessageBox.Show("L'adresse IP spécifiée n'est pas au bon format.", "Attention", MessageBoxButtons.OK);
        //            return;
        //        }
        //        btnSend.Enabled = true;
        //        btnConnect.Text = "Disconnect";
        //    }
        //    else if (btnConnect.Text == "Disconnect")
        //    {
        //        if (client != null)
        //            client.disconnect();
        //        btnSend.Enabled = false;
        //        btnConnect.Text = "Connect";
        //    }
        //}

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                byte[] msg = imageToByteArray(pictureBox.Image);
                byte[] count = new byte[8];
                count = BitConverter.GetBytes(msg.Length);
                byte[] msgSend = new byte[8 + msg.Length];
                count.CopyTo(msgSend, 0);
                msg.CopyTo(msgSend, 8);
                client.send(msgSend);
            }
            else
            {
                MessageBox.Show("Please choose your image to send!");
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(file);
            }
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            file = "";
            openFileDialog.Filter = "JPEG files (*.jpg) |*.jpg";
        }

        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream ms = new MemoryStream())
            {
                //BinaryFormatter formatter = new BinaryFormatter();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //formatter.Serialize(ms,imageIn);
                ms.Close();
                byteArray = ms.ToArray();
            }
            return byteArray;
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog.FileName;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(file);
            }
        }
    }
}
