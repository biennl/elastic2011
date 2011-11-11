using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Utils
{
    class Utils : SocketServices
    {

        private static Utils instance;
        private static TcpListener tcpListener;
        private static Socket socket;
        public static SocketShutdown bothShutDown = SocketShutdown.Both;

        private Utils() { }

        public static Utils getInstance()
        {

            if (instance == null)
                instance = new Utils();

            return instance;

        }



        private static TcpListener NewTcpListener(int port)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            server.Start();
            return server;
        }

        void SocketServices.CreateNewTcpListener(int port)
        {
            tcpListener = NewTcpListener(port);
        }

        TcpListener SocketServices.GetTcpListener()
        {
            return tcpListener;
        }

        void SocketServices.SetTcpListener(TcpListener tcp_Listener)
        {
            tcpListener = tcp_Listener;
        }

        private static Socket NewSocket(string host, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] address = Dns.GetHostAddresses(host);
            socket.Connect(address, port);
            return socket;
        }

        void SocketServices.CreateNewSocket(string host, int port)
        {
            socket = NewSocket(host, port);
        }

        Socket SocketServices.GetSocket()
        {
            return socket;
        }

        void SocketServices.SetSocket(Socket s)
        {
            socket = s;
        }

        void SocketServices.SocketSend(Socket socket, byte[] bytes)
        {
            int offset = 0;
            while (offset < bytes.Length)
            {
                int sent = socket.Send(bytes, offset, bytes.Length - offset, SocketFlags.None);
                offset += sent;
            }
        }

        byte[] SocketServices.SocketReceive(Socket socket, int count)
        {
            byte[] bytes = new byte[count];
            int offset = 0;
            if (count == 0)
            {
                socket.Receive(bytes, 0, 0, SocketFlags.None);
                return bytes;
            }
            while (offset < count)
            {
                int received = socket.Receive(bytes, offset, count - offset, SocketFlags.None);
                if (received == 0) throw new SystemException("Socket déconnectée");
                offset += received;
            }
            return bytes;
        }

        byte[] SocketServices.StringToUTF8(string message)
        {
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            return utf8Encoding.GetBytes(message);
        }

        string SocketServices.UTF8ToString(byte[] message)
        {
            UTF8Encoding utf8Encoding = new UTF8Encoding();
            return utf8Encoding.GetString(message);
        }

    }
}