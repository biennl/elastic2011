using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncodingLibrary;
using MessagesLibrary;
using NetworkLibrary;
using System.Threading;

// la librairie des services et le CatalogService reference MessageLibrary
// et EncodingLibrairy 
namespace CatalogService
{
    public class Catalog : ICatalog
    {

        /// <summary>
        /// services fait correspondre un service à son adresse
        /// </summary>
        /// 
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Port { get; set; }
        public NetworkManager NetworkManager { get; set; }
        public IListener Listener { get; set; }
        public ISenderReceiver SenderReceiver { get; set; }
        public MsgEncoding EncodingMessage { get; set; }
        public Thread ListenClientThread { get; set; }
        public List<Thread> AcceptedThreadList { get; set; }
        public List<ISenderReceiver> AcceptedSenderReceiverList { get; set; }
        Dictionary<string, ServiceInfo> Services;

        
        public Catalog(string adress, int port)
        {
            this.Adress = adress;
            this.Port = port;
            this.EncodingMessage = new MsgEncoding();
            this.Services = new Dictionary<string, ServiceInfo>();
            this.NetworkManager = new NetworkManager();
            this.Listener = NetworkManager.createListner(adress, port);
            this.ListenClientThread = new Thread(this.listenClient);
            this.AcceptedSenderReceiverList = new List<ISenderReceiver>();
            this.AcceptedThreadList = new List<Thread>();
        }
        /// <summary>
        /// demarre le service de registration
        /// <param ></param>
        /// <returns></returns>
        /// </summary>
        
        public void startService()
        {
            if (ListenClientThread == null)
                ListenClientThread = new Thread(this.listenClient);
            ListenClientThread.Start();
        }

        //stop le service
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

        //cette methode ecoute les requetes des clients 
        //et demarre un thread de communication 
        public void listenClient()
        {
            while (true)
            {
                ISenderReceiver socketClient = Listener.accept();
                Thread threadClient = new Thread(this.analyseClientsMessage);
                threadClient.Start((Object)socketClient);
            }
        }

        //fonction qui analyse le message envoyé par le client et se charge de lui envoyer
        //un message correspondant a sa requete ( register , unregister , getinfos ) 
        public void analyseClientsMessage(Object ObjectsocketClient)
        {
            ISenderReceiver socketClient = (ISenderReceiver)ObjectsocketClient;
            Byte[] messageClientByte = socketClient.receive();
            Byte[] bytesResult = analyseMessage(messageClientByte);
            if(bytesResult != null)
                socketClient.send(bytesResult);
            socketClient.close();
        }

        /// <summary>
        /// fonction qui enregistre un service
        /// <returns></returns>
        /// </summary>
        public void Register(string service, string title, string address, string port)
        {

            if (Services.ContainsKey(title)) throw new Exception("Service registering error: no duplicate service! ");
            Services.Add(title, new ServiceInfo(service, address, port));
        }

        // desenregistre le client
        public void Unregister(string service)
        {
            if (string.IsNullOrEmpty(service)) throw new Exception("unregister service : parameter null");
            Services.Remove(service);
        }

        //fournit les information sur tous les services enregistrés 
        public List<string> GetInfos(string title)
        {
            List<string> listParameters = new List<string>();
            if (title != "")
            {
                if (Services.ContainsKey(title))
                {
                    ServiceInfo serviceInfo = Services[title];
                    listParameters.Add(serviceInfo.Service);
                    listParameters.Add(title);
                    listParameters.Add(serviceInfo.Address);
                    listParameters.Add(serviceInfo.Port);
                }
                else
                {
                    listParameters.Add("");
                    listParameters.Add("");
                    listParameters.Add("");
                    listParameters.Add("");
                }
            }
            else
            {
                foreach (string key in Services.Keys)
                {
                    ServiceInfo sInfo = Services[key];
                    listParameters.Add(sInfo.Service);
                    listParameters.Add(key);
                    listParameters.Add(sInfo.Address);
                    listParameters.Add(sInfo.Port);
                }
            }

            return listParameters;

        }

        /// <summary>
        ///  analyseMessage permet au serveur CATALOGUE de ne pas se préocuper 
        ///  des opérations d'encodage/décodage, exécution d'opération
        ///  traite le tableau de bytes reçu par le server
        ///  Elle verifie quelle est l'operation concernée, et l'éxécute.
        ///  elle revoie un message encodé au cas échéant.
        /// </summary>                   
        /// <param name="msgBytes"></param>
        /// <returns></returns>
        public byte[] analyseMessage(byte[] msgBytes)
        {

            
            ServiceMessage message = (ServiceMessage)EncodingMessage.Decode(msgBytes);

            int Count = message.Count;
            string Source = message.Source;
            string Target = message.Target;
            string Operation = (message.Operation).ToLower();
            string Stamp = message.Stamp;
            int ParametersCount = message.ParamCount;
            List<string> ParametersList = message.ListParams;

            if (Operation.Equals("register"))
            {
                try
                {
                    Register(ParametersList[0], ParametersList[1], ParametersList[2], ParametersList[3]);
                    return null;
                }
                catch (Exception e)
                {
                    ServiceMessage messageError = new ServiceMessage(Target, Source, "Diagnostic", Stamp, 1);
                    messageError.ListParams.Add(e.Message);
                    return EncodingMessage.Encode(messageError);
                }
            }
            else if (Operation.Equals("unregister"))
            {
                try
                {
                    this.Unregister(ParametersList[0]);
                    return null;
                }
                catch (Exception e)
                {
                    ServiceMessage messageError = new ServiceMessage(Target, Source, "Diagnostic", Stamp, 1);
                    messageError.ListParams.Add(e.Message);
                    return EncodingMessage.Encode(messageError);
                }
            }
            else if (Operation.Equals("getinfos"))
            {
                List<string> listeParameters = this.GetInfos(ParametersList[0]);
                ServiceMessage messageInformations = new ServiceMessage(Target, Source, "getInfos", Stamp, listeParameters.Count());
                messageInformations.ListParams = listeParameters;
                return EncodingMessage.Encode(messageInformations);
            }
            return null;
        }
        /// <summary>
        ///  methode utilitaire : sert à déléguer le decodage à catalog
        ///  et renvoyer le message correspondant;   
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public ServiceMessage decode(byte[] bytes)
        {
            MsgEncoding encodMessage = new MsgEncoding();
            return encodMessage.Decode(bytes);
        }

        public string displayCatalog()
        {
            string display = " ";
            List<string> services = GetInfos("");
            for (int i = 0; i < services.Count(); i += 4)
            {
                display += services[i + 0] +
                " " + services[i + 1] + " " + services[i + 2] + " " + services[i + 3] + " \n";
            }
            return display;
        }
    }

}
