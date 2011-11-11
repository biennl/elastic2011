using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MessagesLibrary;
using NetworkLibrary;
using EncodingLibrary;

namespace EchoService.cs
{   //class represent the echo service
    public class EchoService
    {
        public String name {get; set;}
        public int port { get; set; }
        //objetcs for communication througth the network 
        NetworkManager manager { get; set; }
        IListener listener { get; set; }
        //encoding object
        public MsgEncoding encoding{ get; set; }
        //thread execute listeningCLient method
        private Thread threadListener;
       
        
        public EchoService(int port)
        {
            this.name = "echoService";
            this.port = port;
            this.encoding = new MsgEncoding();
            this.manager = new NetworkManager();
            this.listener = manager.createListner("127.0.0.1", port);
            this.threadListener = new Thread(this.EchoServiceClients);
            this.threadListener.Start();
        }

        public void EchoServiceClients()
        {
            while (true)
            {
                ISenderReceiver sndr=listener.accept();
                Message receive = encoding.Decode(sndr.receive());
                sndr.send(encoding.Encode(receive));
            }
        }      

    }
}
