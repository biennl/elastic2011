using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{

    public class Message
    {
        private int count;
        private List<MessageItem> lsItems;

        public Message(String src,String tgt,String op,String stp,int nbParams)
        {
            lsItems = new List<MessageItem>();
            MessageItem source = new MessageItem("string", "utf-8", "source", true, src);
            MessageItem target = new MessageItem("string", "utf-8", "target", true, tgt);
            MessageItem operation = new MessageItem("string", "utf-8", "operation", true, op);
            MessageItem stamp = new MessageItem("string", "utf-8", "stamp", true, stp);
            MessageItem nbrparams = new MessageItem("int", "binaire", "paramCount", true, nbParams);
            lsItems.Add(source);
            lsItems.Add(target);
            lsItems.Add(operation);
            lsItems.Add(stamp);
            lsItems.Add(nbrparams);
        }
    }
}
