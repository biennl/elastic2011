using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
     public class ErrorMessage : Message
    {
        public string ErrorMessage { get; set; }

        public ErrorMessage(String errorMessage,String source,String target,string stamp)
        {
            this.ErrorMessage = errorMessage;
            this.Source = source;
            this.Target=target;
            this.Stamp = stamp;
            this.Operation = "diagnostique";
            this.ParamCount = 1;
        }
    }
}
