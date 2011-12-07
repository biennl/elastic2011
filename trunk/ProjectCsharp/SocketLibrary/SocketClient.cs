using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SocketLibrary
{
    public class Client : IClient
    {
        private IPEndPoint ipEnd;
        private Socket socket;
        //private Thread receiveThread;
        private bool sendLock;

        internal Client(string ip, int port)
        {
            this.ipEnd = new IPEndPoint(IPAddress.Parse(ip), port);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.sendLock = false;
        }

        public bool connect()
        {
            try
            {
                this.socket.Connect(ipEnd);
                //this.receiveThread = new Thread(receiveMsg);
                //this.receiveThread.Start();
                return true;
            }
            catch { return false; }
        }

        public void disconnect()
        {
            if (socket != null)
                socket.Close();
            //if (receiveThread != null)
            //    receiveThread.Abort();
        }

        public void send(byte[] msg)
        {
            try
            {
                if (!sendLock)
                {
                    socket.Send(msg, SocketFlags.None);
                    //sendLock = true;
                }
            }
            catch { }
        }

        public void receiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] count = new byte[8];
                    socket.Receive(count, count.Length, SocketFlags.None);

                    byte[] msg = new byte[BitConverter.ToInt64(count, 0)];
                    socket.Receive(msg, msg.Length, SocketFlags.None);

                    sendLock = false;
                }
                catch { break; }
            }
        }
    }

    public class ClientEventArgs : EventArgs
    {
        public byte[] Msg { get; set; }
        public ClientEventArgs(byte[] msg)
        {
            this.Msg = msg;
        }
    }
}
