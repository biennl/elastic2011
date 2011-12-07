using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NetworkLibrary;
using MessagesLibrary;
using EncodingLibrary;

namespace CatalogService
{
    /// <summary>
    /// les trois méthodes obligatoires pour un implementer un service 
    /// </summary>
    public interface IService
    {        
        
        void startService();
        void stopService();
        void listenClient();
    }
}
