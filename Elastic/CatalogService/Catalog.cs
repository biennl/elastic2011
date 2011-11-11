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
        private Hashtable services;

        public Catalog()
        {
            services = new Hashtable();
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

        public CatalogMessage GetInfos(string service)
        {



            return null;
        }

    }
}
