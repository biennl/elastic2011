using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MessagesLibrary;
using NetworkLibrary;
using EncodingLibrary;

namespace EchoService
{
    //class represent the echo service
    public class Echo
    {
        public String name { get; set; }
        public int port { get; set; }
        public string adress{get; set;}
        //objetcs for communication througth the network 
        NetworkManager manager { get; set; }
        IListener listener { get; set; }
        //encoding object
        public MsgEncoding encoding { get; set; }
        //thread execute listeningCLient method
        private Thread threadListener;


        public Echo(string adress, int port)
        {
            this.adress=adress;
            this.name = "echoService";
            this.port = port;
            this.encoding = new MsgEncoding();
            this.manager = new NetworkManager();
            this.listener = manager.createListner(adress, port);
        }

        public void EchoServiceClients()
        {
            while (true)
            {
                ISenderReceiver sndr = listener.accept();
                ServiceMessage receive = encoding.Decode(sndr.receive());
                sndr.send(encoding.Encode(receive));
            }
        }

        public void RegisterService() 
        {
            ServiceMessage register = new ServiceMessage();
            register.Operation = "register";
            register.Source="
        }

        public void UnRegisterMessage()
        {

        }
    }
}
