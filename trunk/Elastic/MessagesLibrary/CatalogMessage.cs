using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace MessagesLibrary
{
    public class CatalogMessage:Message
    {
        public List<string> ListParams { get; set; }

        public CatalogMessage(List<string> listParams)
        {
            this.ListParams = listParams;
        }
    }
}
