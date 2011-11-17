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
                        ServiceMessage m = encoding.Decode(messageBytes);

                        if (m.Target == ("echoService"))
                        {
                            if (m.Operation.Equals("echo"))
                            {
                                if (m.ListParams.Count == 1)
                                {
                                    ServiceMessage retMsg = new ServiceMessage(m.Target, m.Source, "callbackEcho", m.Stamp, 1);
                                    retMsg.ListParams.Add(this.echoOperation(m.ListParams.ElementAt(0)));
                                    senderReceveir.send(encoding.Encode(retMsg));
                                }
                            }
                        }
                        else
                        {
                            ServiceMessage msgError = new ServiceMessage(this.adress, m.Source, "Diagnostic", m.Stamp, 1);
                            msgError.ListParams.Add("we don't supply the service you want ");
                            senderReceveir.send(encoding.Encode(msgError));
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
            register.Source = this.adress;
            register.Stamp = "";
            register.ParamCount = 4;
            register.ListParams.Add("service");
            register.ListParams.Add("echo");
            register.ListParams.Add(this.adress);
            register.ListParams.Add(this.port.ToString());
            registerSender = this.manager.createSenderReceiver(catalogAddress, catalogPort);
            registerSender.send(this.encoding.Encode(register));
        }

        public void UnregisterService(string catalogAddress,int catalogPort)
        {
            ServiceMessage unregister = new ServiceMessage();
            unregister.Operation = "Unregister";
            unregister.Target = "127.0.0.1";
            unregister.Source = this.adress;
            unregister.Stamp = "";
            unregister.ParamCount = 1;
            unregister.ListParams.Add("echo");
            registerSender = this.manager.createSenderReceiver(catalogAddress, catalogPort);
            registerSender.send(this.encoding.Encode(unregister));
        }
    }
}
