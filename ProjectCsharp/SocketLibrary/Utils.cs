using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketLibrary
{
    public class Utils
    {
        public static IClient CreateClient(string add, int port)
        {
            return new Client(add, port);
        }

        public static IServer CreateServer(int port)
        {
            return new Server(port);
        }
    }

    public interface IClient
    {
        bool connect();

        void send(byte[] msg);

        void disconnect();

    }

    public interface IServer
    {
        bool start();

        void stop();

        void subscribe(Action<object, ServerEventArgs> listener);

        void unsubscribe();
    }
}
