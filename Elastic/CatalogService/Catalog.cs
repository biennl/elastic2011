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

        public void GetInfos(string service)
        {
            
        }

    }
}
