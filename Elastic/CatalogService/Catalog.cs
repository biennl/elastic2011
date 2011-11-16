using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncodingLibrary;
using MessagesLibrary;

// la librairy CatalogService reference MessageLibrary
// et 
namespace CatalogService
{
    public class Catalog : ICatalog
    {
     
        /// <summary>
        /// services fait correspondre un service à son adresse
        /// </summary>
        Dictionary<string, ServiceInfo> services  ;

        //public Dictionary<string, ServiceInfo> getServices()
        //{
           //return services;
        //}

        public Catalog()
        {
            this.services = new Dictionary<string, ServiceInfo>();
            //add a static service for tester.
            this.services.Add("echo1",new ServiceInfo("service","127.0.0.1","20000"));
            this.services.Add("echo2", new ServiceInfo("service", "127.0.0.1", "22000"));

        }
        public void Register(string service, string title, string address, string port)
        {
   
            if (services.ContainsKey(title)) throw new Exception("Service registering error: no duplicate service! ");
            services.Add(title, new ServiceInfo(service, address, port));
        }

        public void Unregister(string service)
        {
            if (string.IsNullOrEmpty(service)) throw new Exception("unregister service : pram null");
                services.Remove(service); 
        }

        public List<string> GetInfos(string title)

        {
            List<string> listParams = new List<string>();
            if (title != "")
            {
                if (services.ContainsKey(title))
                {
                    ServiceInfo serviceInfo = services[title];
                    listParams.Add(serviceInfo.Service);
                    listParams.Add(title);
                    listParams.Add(serviceInfo.Address);
                    listParams.Add(serviceInfo.Port);
                }
                else
                {
                    listParams.Add("");
                    listParams.Add("");
                    listParams.Add("");
                    listParams.Add("");
                }
            }
            else
            {
                foreach (string key in services.Keys)
                {
                    ServiceInfo sInfo = services[key];
                    listParams.Add(sInfo.Service);
                    listParams.Add(key);
                    listParams.Add(sInfo.Address);
                    listParams.Add(sInfo.Port);
                }
            }

           // CatalogMessage msg = new CatalogMessage(listParams);
            return listParams;

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

            MsgEncoding encodMsg = new MsgEncoding();
            ServiceMessage msg = (ServiceMessage)encodMsg.Decode(msgBytes);            

            int count = msg.Count;
            string source = msg.Source;
            string target = msg.Target;
            string operation = (msg.Operation).ToLower();
            string stamp = msg.Stamp;
            int parmCount = msg.ParamCount;            
            List<string> paramList = msg.ListParams;
                
            if (operation.Equals("register"))
            {
                try
                {
                    this.Register(paramList[0], paramList[1], paramList[2], paramList[3]);
                    return null;
                }
                catch (Exception e)
                {
                    ServiceMessage msgError = new ServiceMessage(target, source, "Diagnostic",stamp,1);
                     msgError.ListParams.Add(e.Message);
                     return encodMsg.Encode(msgError);
                }
            }
            else if (operation.Equals("unregister"))
            {
                try
                {
                    this.Unregister(paramList[0]);
                    return null;
                }
                catch (Exception e)
                {
                    ServiceMessage msgError = new ServiceMessage(target, source, "Diagnostic", stamp, 1);
                    msgError.ListParams.Add(e.Message);
                    return encodMsg.Encode(msgError);
                }
            }
            else if (operation.Equals("getinfos"))
            {                  
                List<string> listParams = this.GetInfos(paramList[0]);
                ServiceMessage msgInfos = new ServiceMessage(target, source, "getInfos", stamp, listParams.Count());
                msgInfos.ListParams = listParams;
                return encodMsg.Encode(msgInfos);               
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
            MsgEncoding encodMsg = new MsgEncoding();
            return encodMsg.Decode(bytes);
        }
    }
}
