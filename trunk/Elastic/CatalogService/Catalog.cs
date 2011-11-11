using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncodingLibrary;
using MessagesLibrary;
using System.Collections;

// la librairy CatalogService reference MessageLibrary
// et 
namespace CatalogService
{
    public class Catalog : ICatalog
    {
        private Dictionary<string, ServiceInfo> services;

        public Catalog()
        {
            services = new Dictionary<string, ServiceInfo>();
        }
        void Register(string service, string title, string address, string port)
        {

            services.Add(title, new ServiceInfo(service, address, port));
        }

        void Unregister(string service)
        {
            //for(int i= 0; i < ServiceInfo si in services){
            //    if( si.Title.Equals(service) )
            //    {
            //        services.ElementAt(
            //    }
            //}

        }

        public CatalogMessage GetInfos(string title)
        {
            List<string> listParams = new List<string>();
            if (title != "")
            {
                if (!services.ContainsKey(title))
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

            CatalogMessage msg = new CatalogMessage(listParams);
            return msg;
        }

    }
}
