using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworkLibrary;
using EncodingLibrary;
using MessagesLibrary;


namespace ClientIHM
{
    //classe qui represente l'IHM d'un client du service message
    public partial class ClientForm : Form
    {
        NetworkManager NetworkManager;
        ISenderReceiver SenderReceiver;
        ISenderReceiver SenderReceiverEcho;
        IMessageEncoding Encode;
        bool IsConnect = false;
        
        // adresse par defaut du client 
        private string catalogAddress = "127.0.0.1";
        private int catalogPort = 50000;

        public ClientForm()
        {
            InitializeComponent();
            NetworkManager = new NetworkManager();
            Encode = new MsgEncoding();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            //ConnectCatalogService();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectCatalogService();
            lbInfo.Text = "";
        }

        private void ConnectCatalogService()
        {
            try
            {
                SenderReceiver = NetworkManager.createSenderReceiver(catalogAddress, catalogPort);
                IsConnect = true;
            }
            catch (Exception e)
            {
                lbInfo.ForeColor = Color.Blue;
                setText("Catalog server is not available.");
            }
        }

        private void ConnectService(string address, int port)
        {
            SenderReceiverEcho = NetworkManager.createSenderReceiver(address, port);
        }



        #region Delegate methods
        private delegate void displayDelegate(byte[] repBytes);
        private void displayAvailableServices(byte[] repBytes)
        {
            if (dgvServicesInfo.InvokeRequired)
            {
                displayDelegate sd = new displayDelegate(displayAvailableServices);
                this.Invoke(sd, new object[] { repBytes });
            }
            else
            {
                dgvServicesInfo.Rows.Clear();
                ServiceMessage msg = Encode.Decode(repBytes);
                List<string> listServices = msg.ListParams;
                for (int i = 0; i < msg.ListParams.Count; i += 4)
                {
                    dgvServicesInfo.Rows.Add(msg.ListParams[i], msg.ListParams[i + 1], msg.ListParams[i + 2], msg.ListParams[i + 3]);
                    dgvServicesInfo.Refresh();
                }
            }
        }

        private delegate void setTextDelegate(string s);
        private void setText(string s)
        {
            if (lbInfo.InvokeRequired)
            {
                setTextDelegate sd = new setTextDelegate(setText);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                lbInfo.Text = s;
            }
        }

        private delegate void displayTextDelegate(string s);
        private void displayText(string s)
        {
            if (rtbDisplay.InvokeRequired)
            {
                displayTextDelegate sd = new displayTextDelegate(displayText);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                rtbDisplay.Text += s + "\n";
            }
        }
        #endregion

        private void btnRequest_Click(object sender, EventArgs e)
        {
            dgvServicesInfo.Rows.Clear();
            if (IsConnect)
            {
                ServiceMessage message = new ServiceMessage("Machine A", "Catalog Service", "getInfos", "Catalog Service Stamp", 1);
                message.ListParams.Add(tbService.Text);

                SenderReceiver.send(Encode.Encode(message));
            }
            else
            {
                lbInfo.ForeColor = Color.Blue;
                setText("You must connect to Catalog service first.");
            }
        }

        private void btnReach_Click(object sender, EventArgs e)
        {
            if (dgvServicesInfo.Rows.Count == 2)
            {
                if (dgvServicesInfo.Rows[0].Cells[1].Value != null)
                {
                    string serviceName = dgvServicesInfo.Rows[0].Cells[1].Value.ToString();
                    ConnectService(dgvServicesInfo.Rows[0].Cells[2].Value.ToString(),
                        Convert.ToInt32(dgvServicesInfo.Rows[0].Cells[3].Value.ToString()));

                    lbInfo.ForeColor = Color.Green;
                    setText("You are connecting to the " + serviceName.ToUpper() + " service.");
                }
                else
                {
                    lbInfo.ForeColor = Color.Red;
                    setText("No service available!");
                }
            }
            else if (dgvServicesInfo.Rows.Count > 2)
            {
                if (dgvServicesInfo.SelectedRows.Count > 0)
                {
                    string serviceName = dgvServicesInfo.SelectedRows[0].Cells[1].Value.ToString();
                    ConnectService(dgvServicesInfo.SelectedRows[0].Cells[2].Value.ToString(),
                        Convert.ToInt32(dgvServicesInfo.SelectedRows[0].Cells[3].Value.ToString()));

                    lbInfo.ForeColor = Color.Green;
                    setText("You are connecting to the " + serviceName.ToUpper() + " service.");
                }
                else
                {
                    lbInfo.ForeColor = Color.Red;
                    setText("You must select a service in the list.");
                }
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ServiceMessage message = new ServiceMessage("Machine A", "echoService", "echo", "Echo Service Stamp", 1);
            message.ListParams.Add(rtbInput.Text);
            try
            {
                SenderReceiverEcho.send(Encode.Encode(message));
                rtbInput.Text = "";
            }
            catch (Exception ex)
            {
                rtbDisplay.Text += "You are not connected.\n";
                rtbInput.Text = "";
            }

        }

        private void rtbInput_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rtbInput.Text))
                this.AcceptButton = btnSend;
            else this.AcceptButton = null;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SenderReceiverEcho.close();
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((this.SenderReceiver != null) && (this.SenderReceiver.available() != 0))
            {
                displayAvailableServices(SenderReceiver.receive());
            }

            if ((this.SenderReceiverEcho != null) && (this.SenderReceiverEcho.available() != 0))
            {
                string str = Encode.Decode(SenderReceiverEcho.receive()).ListParams[0];
                displayText(str);
            }
        }

        private void btnSend100_Click(object sender, EventArgs e)
        {
            ServiceMessage message = new ServiceMessage("Machine A", "echoService", "echo", "Echo Service Stamp", 1);
            message.ListParams.Add("Hello Test !");
            for (int i = 0; i < 100; i++)
            {   
                try
                {
                   
                    SenderReceiverEcho.send(Encode.Encode(message));
                    rtbInput.Text = "";
                }
                catch (Exception ex)
                {
                    rtbDisplay.Text += "You are not connected.\n";
                    rtbInput.Text = "";
                }
            }
        }


    }
}
