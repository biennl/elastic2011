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
    public class Catalog  : ICatalog
    {

        private List<ServiceInfo> services;
              
        public Catalog(){
            services = new List<ServiceInfo>();
        }
        void Register(string service, string title, string address, string port)
        {
            services.Add(new ServiceInfo(service,title,address,port));
        }

        void Unregister(string service)
        { 
        }

        public CatalogMessage GetInfos(string service)
        {
            List<string> listParams = new List<string>();
            
            CatalogMessage msg = new CatalogMessage(listParams);


            return msg;
        }

    }
}
