using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

//  CatalogMessage sera utilisé par l'annuaire pour envoyer des messages 
// en retour à getInfos(String service);
// En fait ces msg ont un format particulier (avec list de params) 

namespace MessagesLibrary
{
    public class CatalogMessage : Message
    {
        public List<string> ListParams { get; set; }

        public CatalogMessage(List<string> listParams)
        {
            this.ListParams = listParams;
        }
    }
}
