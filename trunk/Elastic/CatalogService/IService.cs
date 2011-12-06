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
    public interface IService
    {        
        //les trois méthodes obligatoire pour un sevice de catalogue
        void startService();
        void stopService();
        void listenClient();
    }
}
