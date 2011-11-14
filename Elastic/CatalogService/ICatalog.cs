using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace CatalogService
{
    public interface ICatalog
    {
        void Register(string service, string title, string address, string port);
        void Unregister(string service);
        List<string> GetInfos(string service);
       byte[] analyseMessage(byte[] msgBytes);
    }
}
