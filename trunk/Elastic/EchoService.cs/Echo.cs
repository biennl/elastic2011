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
        public string adress { get; set; }
        //objetcs for communication througth the network 
        NetworkManager manager { get; set; }
        IListener listener { get; set; }
        //encoding object
        public MsgEncoding encoding { get; set; }
        //thread execute listeningCLient method
        public List<ISenderReceiver> sendersReceivers { get; set; }
        string currentMsg;



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
                    this.sendersReceivers.Add(sndr);
                }

                foreach (ISenderReceiver sr in this.sendersReceivers)
                {
                    if (sr.available() != 0)
                    {
                        ServiceMessage m = encoding.Decode(sr.receive());
                        Console.WriteLine(m.ListParams[0]);
                        if (m.Target.Equals("echoService"))
                        {
                            if (m.Operation.Equals("echo"))
                            {
                                if (m.ListParams.Count == 1)
                                {
                                    ServiceMessage retMsg = new ServiceMessage(m.Target, m.Source, "callbackEcho", m.Stamp, 1);
                                    retMsg.Count = 899;
                                    retMsg.ListParams.Add(this.echoOperation(m.ListParams.ElementAt(0)));
                                    sr.send(encoding.Encode(retMsg));
                                }
                            }
                        }
                        else
                        {
                            ServiceMessage msgError = new ServiceMessage(this.adress, m.Source, "Diagnostic", m.Stamp, 1);
                            msgError.ListParams.Add("we don't supply the service you want ");
                            sr.send(encoding.Encode(msgError));
                        }
                    }


                }
            }
        }

        public void RegisterService(int portRegister)
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
            ISenderReceiver registerSender = this.manager.createSenderReceiver(this.adress, portRegister);
            registerSender.send(this.encoding.Encode(register));
            registerSender.close();
        }

        public void UnregisterService()
        {
            ServiceMessage register = new ServiceMessage();
            register.Operation = "Unregister";
            register.Target = "127.0.0.1";
            register.Source = this.adress;
            register.Stamp = "";
            register.ParamCount = 1;
            register.ListParams.Add("echo");
            ISenderReceiver registerSender = this.manager.createSenderReceiver(this.adress, this.port);
            registerSender.send(this.encoding.Encode(register));
            registerSender.close();
        }
    }
}
