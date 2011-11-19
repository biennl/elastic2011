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
    // classe repreente le service Echo, il utilise le protocole Elastique via 
    // les bibliotheques Encoding, Message, Network

    public class Echo
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string Adress { get; set; }
        NetworkManager Manager { get; set; }
        IListener Listener { get; set; }
        public MsgEncoding Encoding { get; set; }
        public List<Thread> SendersReceivers { get; set; }
        public Thread listenClientThread { get; set; }
        ISenderReceiver RegisterSender;



        public Echo(string adress, int port)
        {
            this.Adress = adress;
            this.Name = "echoService";
            this.Port = port;
            this.Encoding = new MsgEncoding();
            this.Manager = new NetworkManager();
            this.Listener = Manager.createListner(adress, port);
            SendersReceivers = new List<Thread>();
            listenClientThread = new Thread(this.listenClient);
            listenClientThread.Start();
        }

        public string echoOperation(string echo)
        {
            return echo;
        }

        public void listenClient()
        {
            while (true)
            {
                ISenderReceiver socketClient = Listener.accept();
                Thread client = new Thread(receiveDataFromClient);
                client.Start(socketClient);
                SendersReceivers.Add(client);
            }
        }

        public void receiveDataFromClient(Object OsenderReceiver)
        {
            ISenderReceiver senderReceiver = (ISenderReceiver)OsenderReceiver;
            while (true)
            {

                byte[] messageCount = senderReceiver.receive(4);
                int count = BitConverter.ToInt32(messageCount, 0);

                byte[] messageBytes = senderReceiver.receive(count - 4);
                List<Byte> listBytesMessage = new List<byte>();
                listBytesMessage.AddRange(messageCount);
                listBytesMessage.AddRange(messageBytes);
                ServiceMessage incomingMessage = Encoding.Decode(listBytesMessage.ToArray());


                if (incomingMessage.Target == "echoService")
                {
                    if (incomingMessage.Operation == "echo")
                    {
                        if (incomingMessage.ListParams.Count == 1)
                        {
                            ServiceMessage outgoingMessage = new ServiceMessage(incomingMessage.Target, incomingMessage.Source, "callbackEcho", incomingMessage.Stamp, 1);
                            outgoingMessage.ListParams.Add(this.echoOperation(incomingMessage.ListParams.ElementAt(0)));
                            senderReceiver.send(Encoding.Encode(outgoingMessage));
                        }
                    }
                }
                else
                {
                    ServiceMessage errorMessage = new ServiceMessage(this.Adress, incomingMessage.Source, "Diagnostic", incomingMessage.Stamp, 1);
                    errorMessage.ListParams.Add("we don't supply the service you want ");
                    senderReceiver.send(Encoding.Encode(errorMessage));
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

        public void UnregisterService(string catalogAddress, int catalogPort)
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