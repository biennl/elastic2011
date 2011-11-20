using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace CatalogService
{
    public interface ICatalog :IService
    {
        
        List<string> GetInfos(string service);
        byte[] analyseMessage(byte[] msgBytes);
    }
}
