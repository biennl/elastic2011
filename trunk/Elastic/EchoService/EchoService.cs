using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MessagesLibrary;
using NetworkLibrary;
using EncodingLibrary;
using CatalogService;

namespace EchoService 
{
    // classe repreente le service Echo, il utilise le protocole Elastique via 
    // les bibliotheques Encoding, Message, Network

    public class Echo : IService 
    {
        public string Name { get; set; }
        public int Port { get; set; }
        public string Adress { get; set; }
        public NetworkManager NetworkManager { get; set; }
        public IListener Listener { get; set; }
        public MsgEncoding EncodingMessage { get; set; }
        public List<Thread> AcceptedThreadList { get; set; }
        public List<ISenderReceiver> AcceptedSenderReceiverList { get; set; }
        public Thread ListenClientThread { get; set; }
        ISenderReceiver RegisterSender;

        public string History { get; set; }



        public Echo(string adress, int port)
        {
            History = "";
            this.Adress = adress;
            this.Name = "echoService";
            this.Port = port;
            this.EncodingMessage = new MsgEncoding();
            this.NetworkManager = new NetworkManager();
            this.Listener = NetworkManager.createListner(adress, port);
            this.AcceptedThreadList = new List<Thread>();
            this.AcceptedSenderReceiverList = new List<ISenderReceiver>();
            ListenClientThread = new Thread(this.listenClient);
        }

        public void startService()
        {

            ListenClientThread = new Thread(this.listenClient);
            ListenClientThread.Start();

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
                Thread clientThread = new Thread(receiveDataFromClient);
                clientThread.Start(socketClient);
                AcceptedThreadList.Add(clientThread);
                AcceptedSenderReceiverList.Add(socketClient);
            }
        }

        public void receiveDataFromClient(Object OsenderReceiver)
        {
            ISenderReceiver senderReceiver = (ISenderReceiver)OsenderReceiver;
            while (true)
            {

                byte[] messageBytes = senderReceiver.receive();
                Message incomingMessage = EncodingMessage.Decode(messageBytes);

                History += DateTime.Now.ToLongDateString()+" ->\"" + incomingMessage.ListParams[0] + "\" received from " + incomingMessage.Source+"\n";

                if (incomingMessage.Target == ("echoService"))
                {
                    if (incomingMessage.Operation.Equals("echo"))
                    {
                        if (incomingMessage.ListParams.Count == 1)
                        {
                            Message outcomingMessage = new Message(incomingMessage.Target, incomingMessage.Source, "callbackEcho", incomingMessage.Stamp, 1);
                            outcomingMessage.ListParams.Add(this.echoOperation(incomingMessage.ListParams.ElementAt(0)));
                            senderReceiver.send(EncodingMessage.Encode(outcomingMessage));
                        }
                    }
                }
                else
                {
                    Message errorMessage = new Message(this.Adress, incomingMessage.Source, "Diagnostic", incomingMessage.Stamp, 1);
                    errorMessage.ListParams.Add("we don't supply the service you want ");
                    senderReceiver.send(EncodingMessage.Encode(errorMessage));
                }

            }
        }

        public void stopService()
        {
            ListenClientThread.Abort();
            ListenClientThread = null;
            Listener.close();
            foreach (Thread thread in AcceptedThreadList)
            {
                thread.Abort();

            }
            foreach (ISenderReceiver senderReceiver in AcceptedSenderReceiverList)
            {
                senderReceiver.close();
            }
        }

        public void Register(string catalogAddress, int catalogPort)
        {
            Message register = new Message();
            register.Operation = "Register";
            register.Target = "127.0.0.1";
            register.Source = Adress;
            register.Stamp = "";
            register.ParamCount = 4;
            register.ListParams.Add("service");
            register.ListParams.Add("echo");
            register.ListParams.Add(Adress);
            register.ListParams.Add(Port.ToString());
            RegisterSender = NetworkManager.createSenderReceiver(catalogAddress, catalogPort);
            RegisterSender.send(EncodingMessage.Encode(register));
        }

        public void Unregister(string catalogAddress, int catalogPort)
        {
            Message unregister = new Message();
            unregister.Operation = "Unregister";
            unregister.Target = "127.0.0.1";
            unregister.Source = Adress;
            unregister.Stamp = "";
            unregister.ParamCount = 1;
            unregister.ListParams.Add("echo");
            RegisterSender = NetworkManager.createSenderReceiver(catalogAddress, catalogPort);
            RegisterSender.send(EncodingMessage.Encode(unregister));
        }
    }
}