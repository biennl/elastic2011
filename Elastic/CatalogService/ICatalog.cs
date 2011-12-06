using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace CatalogService
{
    //interface du service catalogue 
    public interface ICatalog :IService
    {
        //les trois methodes obligatoire de tout catalogue
        List<string> GetInfos(string service);
        byte[] analyseMessage(byte[] msgBytes);
        string displayCatalog();
    }
}
