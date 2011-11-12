using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    class ErrorMessage : Message
    {
        public String errorMessage { get; set; }

        public ErrorMessage(String errorMessage,String source,String target,string stamp)
        {
            this.errorMessage = errorMessage;
            this.Source = source;
            this.Target=target;
            this.Stamp = stamp;
            this.Operation = "diagnostique";
            this.ParamCount = 1;
        }
    }
}
