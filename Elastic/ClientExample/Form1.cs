﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworkLibrary;

namespace ClientExample
{
    public partial class Form1 : Form
    {

        NetworkManager networkManager;
        ISenderReceiver senderReceiver;

        public Form1()
        {
            InitializeComponent();
            networkManager = new NetworkManager();
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            senderReceiver = networkManager.createSenderReceiver("127.0.0.1", Convert.ToInt32(this.portBox.Text));
            this.sendButton.Enabled = true;
            this.connexionButton.Enabled = false;
            this.backgroundWorker1.RunWorkerAsync();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            senderReceiver.send(utf8Encoding.GetBytes(this.messageToSendBox.Text));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                
                if ((this.senderReceiver != null) && (this.senderReceiver.available() != 0))
                {
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    //this.MessageReceivedLabel.Text = utf8Encoding.GetString(senderReceiver.receive());
                    setText(utf8Encoding.GetString(senderReceiver.receive()));
                }
            }
        }

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
    }
}
