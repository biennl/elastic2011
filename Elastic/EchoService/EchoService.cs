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
    /
    /// <summary>
    /// cette classe represente  un service d'envoie de message 
    /// </summary>
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

        
        /// <summary>
        /// fonction qui demarre le service
        /// </summary>
        public void startService()
        {
            ListenClientThread = new Thread(this.listenClient);
            ListenClientThread.Start();
        }

        
        /// <summary>
        /// fonction qui represente l'operation echo du service message 
        /// </summary>
        /// <param name="echo"></param>
        /// <returns></returns>
        public string echoOperation(string echo)
        {
            return echo;
        }

        
        /// <summary>
        /// méthode qui ecoute les requetes des client et qui creer une socket
        /// pour gérer la communication entre le client et le service
        /// cette méthode est mise dans un thread 
        /// </summary>
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

        
        /// <summary>
        /// methode qui ecoute les requete d'un client et les affiche cette methode 
        /// mise dans un thread
        /// </summary>
        /// <param name="OsenderReceiver"></param>
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

        //arrete le service
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

        
        /// <summary>
        ///ces deux methodes apelle le serveur "register" pour s'enregistrer
        ///et ce desenregistrer 
        /// </summary>
        /// <param name="catalogAddress"></param>
        /// <param name="catalogPort"></param>
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