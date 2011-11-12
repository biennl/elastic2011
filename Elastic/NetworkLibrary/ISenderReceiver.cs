using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLibrary
{
    public interface ISenderReceiver
    {
        void send(byte[] bytes);
        byte[] receive();
        byte[] receive(int count);
        int available();
        void close();
    }
}
