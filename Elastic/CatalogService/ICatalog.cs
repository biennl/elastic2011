using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace CatalogService
{
     
    /// <summary>
    /// interface minimale et requise pour implementer
    /// un service catalogue 
    /// </summary>
    public interface ICatalog :IService
    {
        List<string> GetInfos(string service);
        byte[] analyseMessage(byte[] msgBytes);
        string displayCatalog();
    }
}
