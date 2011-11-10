using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace EncodingLibrary
{
    public interface IEncoding
    {
        byte[] Encode(Message msg);
        Message Decode(byte[] msgBytes);
    }
}
