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
    public partial class ClientForm : Form
    {
        NetworkManager networkManager;
        ISenderReceiver senderReceiver;
        ISenderReceiver senderReceiverEcho;
        IEncoding encode;
        bool isConnect = false;

        private string catalogAddress = "127.0.0.1";
        private int catalogPort = 50000;

        public ClientForm()
        {
            InitializeComponent();
            networkManager = new NetworkManager();
            encode = new MsgEncoding();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectCatalogService();

            backgroundWorker.RunWorkerAsync();
        }

        private void ConnectCatalogService()
        {
            senderReceiver = networkManager.createSenderReceiver(catalogAddress, catalogPort);
            isConnect = true;
        }

        private void ConnectService(string address, int port)
        {
            senderReceiverEcho = networkManager.createSenderReceiver(address, port);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if ((this.senderReceiver != null) && (this.senderReceiver.available() != 0))
                {
                    displayAvailableServices(senderReceiver.receive());
                }

                if ((this.senderReceiverEcho != null) && (this.senderReceiverEcho.available() != 0))
                {
                    string str = encode.Decode(senderReceiverEcho.receive()).ListParams[0];
                    displayText(str);
                }
            }
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
                ServiceMessage msg = encode.Decode(repBytes);
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
            if (isConnect)
            {
                ServiceMessage msg = new ServiceMessage();
                msg.Count = 899;
                msg.Source = "Machine A";
                msg.Target = "Catalog Service";
                msg.Operation = "getInfos";
                msg.Stamp = "Catalog Service Temp";
                msg.ParamCount = 1;

                msg.ListParams.Add(tbService.Text);
                senderReceiver.send(encode.Encode(msg));
            }
            else
            {
                setText("You are not connected.");
            }
        }

        private void btnReach_Click(object sender, EventArgs e)
        {
            if (dgvServicesInfo.SelectedRows.Count > 0)
            {
                string name = dgvServicesInfo.SelectedRows[0].Cells[1].Value.ToString();
                ConnectService(dgvServicesInfo.SelectedRows[0].Cells[2].Value.ToString(),
                    Convert.ToInt32(dgvServicesInfo.SelectedRows[0].Cells[3].Value.ToString()));

                lbInfo.ForeColor = Color.Black;
                setText("You are connecting to the " + name + " service.");
            }
            else
            {
                lbInfo.ForeColor = Color.Red;
                setText("You must select a service in the list.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ServiceMessage msg = new ServiceMessage();
            msg.Count = 899;
            msg.Source = "Machine A";
            msg.Target = "echoService";
            msg.Operation = "echo";
            msg.Stamp = "Echo Service Stamp";
            msg.ParamCount = 1;

            msg.ListParams.Add(rtbInput.Text);
            senderReceiverEcho.send(encode.Encode(msg));

        }
    }
}
