using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
     public class ErrorMessage : Message
    {
        public string errorMessage { get; set; }

        public ErrorMessage(string errorMessage,string source,string target,string stamp)
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
