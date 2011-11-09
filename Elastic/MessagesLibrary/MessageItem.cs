using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
     public class MessageItem
    {
         public int Count {get;set;}
         public string Type { get; set; }
         public string Codage { get; set; }
         public string Key { get; set; }
         public bool IsMandatory { get; set; }

         
    }
}
