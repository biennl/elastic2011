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
        public string name { get; set; }
        public int port { get; set; }
        public string adress { get; set; }
        //objetcs for communication througth the network 
        NetworkManager manager { get; set; }
        IListener listener { get; set; }
        //encoding object
        public MsgEncoding encoding { get; set; }
        //thread execute listeningCLient method
        public List<ISenderReceiver> sendersReceivers { get; set; }
        string currentMsg;
        ISenderReceiver registerSender;


        public Echo(string adress, int port)
        {
            this.adress = adress;
            this.name = "echoService";
            this.port = port;
            this.encoding = new MsgEncoding();
            this.manager = new NetworkManager();
            this.listener = manager.createListner(adress, port);
            sendersReceivers = new List<ISenderReceiver>();
        }

        public string echoOperation(string echo)
        {
            return echo;
        }

        public void EchoServiceListener()
        {
            while (true)
            {
                if (listener.pending())
                {
                    ISenderReceiver sndr = listener.accept();
                    sendersReceivers.Add(sndr);
                }

                foreach (ISenderReceiver senderReceveir in sendersReceivers)
                {
                    if (senderReceveir.available() != 0)
                    {
                        byte[] messageBytes = senderReceveir.receive();
                        ServiceMessage incomingMessage = encoding.Decode(messageBytes);

                        if (incomingMessage.Target == ("echoService"))
                        {
                            if (incomingMessage.Operation.Equals("echo"))
                            {
                                if (incomingMessage.ListParams.Count == 1)
                                {
                                    ServiceMessage outcomingMessage = new ServiceMessage(incomingMessage.Target, incomingMessage.Source, "callbackEcho", incomingMessage.Stamp, 1);
                                    outcomingMessage.ListParams.Add(this.echoOperation(incomingMessage.ListParams.ElementAt(0)));
                                    senderReceveir.send(encoding.Encode(outcomingMessage));
                                }
                            }
                        }
                        else
                        {
                            ServiceMessage errorMessage = new ServiceMessage(this.adress, incomingMessage.Source, "Diagnostic", incomingMessage.Stamp, 1);
                            errorMessage.ListParams.Add("we don't supply the service you want ");
                            senderReceveir.send(encoding.Encode(errorMessage));
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
            register.Source = adress;
            register.Stamp = "";
            register.ParamCount = 4;
            register.ListParams.Add("service");
            register.ListParams.Add("echo");
            register.ListParams.Add(adress);
            register.ListParams.Add(port.ToString());
            registerSender = manager.createSenderReceiver(catalogAddress, catalogPort);
            registerSender.send(encoding.Encode(register));
        }

        public void UnregisterService(string catalogAddress,int catalogPort)
        {
            ServiceMessage unregister = new ServiceMessage();
            unregister.Operation = "Unregister";
            unregister.Target = "127.0.0.1";
            unregister.Source = adress;
            unregister.Stamp = "";
            unregister.ParamCount = 1;
            unregister.ListParams.Add("echo");
            registerSender = manager.createSenderReceiver(catalogAddress, catalogPort);
            registerSender.send(encoding.Encode(unregister));
        }
    }
}
