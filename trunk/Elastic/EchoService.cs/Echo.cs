﻿using System;
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
        public string Name { get; set; }
        public int Port { get; set; }
        public string Adress { get; set; }
        //objetcs for communication througth the network 
        NetworkManager Manager { get; set; }
        IListener Listener { get; set; }
        //encoding object
        public MsgEncoding Encoding { get; set; }
        //thread execute listeningCLient method
        public List<ISenderReceiver> SendersReceivers { get; set; }
        ISenderReceiver RegisterSender;


        public Echo(string adress, int port)
        {
            this.Adress = adress;
            this.Name = "echoService";
            this.Port = port;
            this.Encoding = new MsgEncoding();
            this.Manager = new NetworkManager();
            this.Listener = Manager.createListner(adress, port);
            SendersReceivers = new List<ISenderReceiver>();
        }

        public string echoOperation(string echo)
        {
            return echo;
        }

        public void EchoServiceListener()
        {
            while (true)
            {
                if (Listener.pending())
                {
                    ISenderReceiver sndr = Listener.accept();
                    SendersReceivers.Add(sndr);
                }

                foreach (ISenderReceiver senderReceveir in SendersReceivers)
                {
                    if (senderReceveir.available() != 0)
                    {
                        byte[] messageBytes = senderReceveir.receive();
                        ServiceMessage incomingMessage = Encoding.Decode(messageBytes);

                        if (incomingMessage.Target == ("echoService"))
                        {
                            if (incomingMessage.Operation.Equals("echo"))
                            {
                                if (incomingMessage.ListParams.Count == 1)
                                {
                                    ServiceMessage outcomingMessage = new ServiceMessage(incomingMessage.Target, incomingMessage.Source, "callbackEcho", incomingMessage.Stamp, 1);
                                    outcomingMessage.ListParams.Add(this.echoOperation(incomingMessage.ListParams.ElementAt(0)));
                                    senderReceveir.send(Encoding.Encode(outcomingMessage));
                                }
                            }
                        }
                        else
                        {
                            ServiceMessage errorMessage = new ServiceMessage(this.Adress, incomingMessage.Source, "Diagnostic", incomingMessage.Stamp, 1);
                            errorMessage.ListParams.Add("we don't supply the service you want ");
                            senderReceveir.send(Encoding.Encode(errorMessage));
                        }
                    }


                }
            }
        }

        public void RegisterService(string catalogAddress, int catalogPort)
        {
            ServiceMessage register = new ServiceMessage();
            register.Operation = "Register";
            register.Target = "127.0.0.1";
            register.Source = Adress;
            register.Stamp = "";
            register.ParamCount = 4;
            register.ListParams.Add("service");
            register.ListParams.Add("echo");
            register.ListParams.Add(Adress);
            register.ListParams.Add(Port.ToString());
            RegisterSender = Manager.createSenderReceiver(catalogAddress, catalogPort);
            RegisterSender.send(Encoding.Encode(register));
        }

        public void UnregisterService(string catalogAddress,int catalogPort)
        {
            ServiceMessage unregister = new ServiceMessage();
            unregister.Operation = "Unregister";
            unregister.Target = "127.0.0.1";
            unregister.Source = Adress;
            unregister.Stamp = "";
            unregister.ParamCount = 1;
            unregister.ListParams.Add("echo");
            RegisterSender = Manager.createSenderReceiver(catalogAddress, catalogPort);
            RegisterSender.send(Encoding.Encode(unregister));
        }
    }
}
