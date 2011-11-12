using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogService
{
    class ServiceInfo
    {
        public string Service { set; get; }
        //public string Title   { set; get; }
        public string Address { set; get; }
        public string Port    { set; get; }

        public ServiceInfo(string service, string address, string port) 
        {
            this.Service   = service;
            this.Address = address;
            this.Port = port;   
        }

    }
}
