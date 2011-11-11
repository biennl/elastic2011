using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogService
{
    interface ICatalog
    {
        void Register(string service, string title, string address, string port);
        void Unregister(string service);
        void GetInfos(string service);  
    }
}
