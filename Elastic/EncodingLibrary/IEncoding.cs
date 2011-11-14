using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace EncodingLibrary
{
    public interface IEncoding
    {
        byte[] Encode(ServiceMessage msg);
        ServiceMessage Decode(byte[] msgBytes);
    }
}
