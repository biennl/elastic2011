using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetworkLibrary;
using System.Threading;
using EchoService;
using MessagesLibrary;

namespace ServeurIHM
{
    

    public partial class Form1 : Form
    {
        NetworkManager networkManger;
        Echo echoService;
        Thread threadListener;
        public Form1()
        {
            
            InitializeComponent();
            echoService = new Echo("127.0.0.1", 50000);
            this.threadListener = new Thread(echoService.EchoServiceListener);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessagesLibrary.ServiceMessage msg = new MessagesLibrary.ServiceMessage();
            msg.Source = "127.0.0.1";
            msg.Target = "127.0.0.1:134";
            msg.Operation = "Register";
            msg.Stamp = "check in";
            msg.ParamCount = 4;             

            this.threadListener.Start();                  


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
