using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Utils
{
    public interface SocketServices
    {

        void CreateNewTcpListener(int port);
        TcpListener GetTcpListener();
        void SetTcpListener(TcpListener tcp_Listener);
        void CreateNewSocket(string host, int port);
        Socket GetSocket();
        void SetSocket(Socket s);
        void SocketSend(Socket socket, byte[] bytes);
        byte[] SocketReceive(Socket socket, int count);
        byte[] StringToUTF8(string message);
        string UTF8ToString(byte[] message);


    }
}
