using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    interface IMessage
    {
       public List<MessageItem> getMessageItems();
       public int getCount();
    }
}
