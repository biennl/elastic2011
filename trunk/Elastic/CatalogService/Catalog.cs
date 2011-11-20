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
        }

        public void startService()
        {
            ListenClientThread.Start();
        }

        public void stopService()
        {

        }

        public void listenClient()
        {
            while (true)
            {
                ISenderReceiver socketClient = Listener.accept();
                Thread threadlient = new Thread(this.analyseClientsMessage);
                threadlient.Start((Object)socketClient);
            }

        }

        public void analyseClientsMessage(Object ObjectsocketClient)
        {
            ISenderReceiver socketClient = (ISenderReceiver)ObjectsocketClient;
            Byte[] countByte = socketClient.receive(4);
            int countMessage = BitConverter.ToInt32(countByte, 0);
            Byte[] messageClientByte = socketClient.receive(countMessage-4);
            List<Byte> messageClientComplete = new List<Byte>();
            messageClientComplete.AddRange(countByte);
            messageClientComplete.AddRange(messageClientByte);
            Byte[] bytesResult = analyseMessage(messageClientComplete.ToArray());
            if(bytesResult != null)
                socketClient.send(bytesResult);
        }

        public void Register(string service, string title, string address, string port)
        {

            if (Services.ContainsKey(title)) throw new Exception("Service registering error: no duplicate service! ");
            Services.Add(title, new ServiceInfo(service, address, port));
        }

        public void Unregister(string service)
        {
            if (string.IsNullOrEmpty(service)) throw new Exception("unregister service : parameter null");
            Services.Remove(service);
        }

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
    }

}
