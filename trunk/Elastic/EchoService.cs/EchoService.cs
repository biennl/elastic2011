using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MessagesLibrary;
using NetworkLibrary;

namespace EchoService.cs
{   //class represent the echo service
    public class EchoService
    {
        public String name {get; set;}
        public int port { get; set; }
        //objetc for communication througth the network 
        public SenderReceiver senderReceiver { get; set; }
       
        
        public EchoService(int port)
        {
            this.name = "echoService";
            this.port = port;
        }

        //send to the rigth client the rigth encoding message
        public void EchoService(Message m)
        {

        }

        public void listenerClients()
        {
            while (true)
            {
                 
            }
        }      

    }
}
