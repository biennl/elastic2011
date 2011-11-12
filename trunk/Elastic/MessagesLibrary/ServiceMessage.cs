using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    class ServiceMessage : Message
    {
        public List<byte[]> ListParams { get; set; }

        public ServiceMessage(List<byte[]> listParams)
        {
            this.ListParams = listParams;
        }
    }
}
