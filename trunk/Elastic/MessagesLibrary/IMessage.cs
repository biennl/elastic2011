using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    public interface IMessage
    {
       int getCount();
       string ToString();
    }
}
