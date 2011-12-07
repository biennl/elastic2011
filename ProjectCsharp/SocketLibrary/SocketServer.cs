using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketLibrary
{
    public class Server : IServer
    {
        private delegate void ServerSocketReceiveEventHandle(Object sender, ServerEventArgs e);
        private event ServerSocketReceiveEventHandle serverSocketReceiveEvent;
        private ServerSocketReceiveEventHandle receive;

        private TcpListener listener;
        private Thread listenerThread;
        private Dictionary<Socket, Thread> clients;
        private int port;

        internal Server(int port)
        {
            this.port = port;
            this.clients = new Dictionary<Socket, Thread>();
        }

        public bool start()
        {
            try
            {
                this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                listenerThread = new Thread(listenConnect);
                listenerThread.Start();
                return true;
            }
            catch
            { return false; }
        }

        public void listenConnect()
        {
            Socket clientSocket = null;
            while (true)
            {
                try
                {
                    clientSocket = listener.AcceptSocket();
                    Thread clientThread = new Thread(receiveClientMsg);
                    clientThread.Start(clientSocket);
                    clients.Add(clientSocket, clientThread);
                }
                catch { break; }
            }
        }

        public void receiveClientMsg(object o)
        {
            Socket cs = (Socket)o;
            while (true)
            {
                try
                {
                    byte[] count = new byte[8];
                    cs.Receive(count, SocketFlags.None);
                    byte[] msg = new byte[BitConverter.ToInt64(count, 0)];
                    cs.Receive(msg, msg.Length, SocketFlags.None);

                    ServerEventArgs e = new ServerEventArgs(cs, msg);
                    serverSocketReceiveEvent(this, e);
                }
                catch
                {
                    if (cs != null)
                    {
                        cs.Close();
                        clients[cs].Abort();
                        clients.Remove(cs);
                    }
                    break;
                }
            }
        }

        public void stop()
        {
            listener.Stop();
            if (listenerThread != null)
                listenerThread.Abort();
            if (clients.Count != 0)
            {
                foreach (Socket cs in clients.Keys)
                {
                    cs.Close();
                    clients[cs].Abort();
                }
            }
        }

        public void subscribe(Action<object, ServerEventArgs> listener)
        {
            receive = new ServerSocketReceiveEventHandle(listener);
            serverSocketReceiveEvent += receive;
        }

        public void unsubscribe()
        {
            serverSocketReceiveEvent -= receive;
        }
    }

    public class ServerEventArgs : EventArgs
    {
        public byte[] Msg { get; set; }

        public Socket SocketClient { get; set; }

        public ServerEventArgs(Socket client, byte[] msg)
        {
            this.Msg = msg;
            this.SocketClient = client;
        }
    }
}
