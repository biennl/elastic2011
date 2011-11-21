using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NetworkLibrary;
using MessagesLibrary;
using EncodingLibrary;

namespace CatalogService
{
    public interface IService
    {
        string Name { get; set; }
        int Port { get; set; }
        string Adress { get; set; }
        NetworkManager NetworkManager { get; set; }
        IListener Listener { get; set; }
        MsgEncoding EncodingMessage { get; set; }
        Thread ListenClientThread { get; set; }
        List<Thread> AcceptedThreadList { get; set; }
        List<ISenderReceiver> AcceptedSenderReceiverList { get; set; }
        
        void startService();
        void stopService();
        void listenClient();
    }
}
