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

         public MessageItem(int Count, string Type, string Codage, string Key, bool IsMandatory) 
         {
             this.Count = Count;
             this.Type = Type;
             this.Codage = Codage;
             this.Key = Key;
             this.IsMandatory = IsMandatory;
         }

         
    }
}
