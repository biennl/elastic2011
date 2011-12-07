using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace EncodingLibrary
{
    /// <summary>
    /// represente l'interface d'un encodeur et decodeur de message
    /// </summary>
    public interface IMessageEncoding
    {
        byte[] Encode(Message msg);
        Message Decode(byte[] msgBytes);
    
    }
}
