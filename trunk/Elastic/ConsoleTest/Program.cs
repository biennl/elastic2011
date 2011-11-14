using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EncodingLibrary;
using MessagesLibrary;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //MsgEncoding encoding = new MsgEncoding();
            IEncoding encoding = new MsgEncoding();
            ServiceMessage msg = new ServiceMessage();
            msg.Count = 899;
            msg.Source = "Machine A";
            msg.Target = "Machine B";
            msg.Operation = "Echo";
            msg.Stamp = "Service Temp";
            msg.ParamCount = 3;

            byte[] count = encoding.Encode(msg);

            Console.WriteLine("Avant: "+msg.ToString());

            ServiceMessage returnMsg = encoding.Decode(count);

            Console.WriteLine("Apres: " + returnMsg.ToString());
        }
    }
}
