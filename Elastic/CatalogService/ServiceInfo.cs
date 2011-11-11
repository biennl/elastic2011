using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogService
{
    class ServiceInfo
    {
        public string Service { get; }
        public string Title   { set; get; }
        public string Address { set; get; }
        public string Port    { set; get; }

        public ServiceInfo(string title, string address, string port) 
        {
            this.Title   = title;
            this.Address = address;
            this.Port = port;
 
        }

    }
}
