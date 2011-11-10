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

        public string Source { get; set; }
        public string Target { get; set; }
        public string Operation { get; set; }
        public string Stamp { get; set; }
        public int ParamCount { get; set; }

        public Message()
        { }
        public Message(String src, String tgt, String op, String stp, int nbParams, String descr)
        {
            lsItems = new List<MessageItem>();
            //each describing string "descr" are null
            //a minimum message contains this 5 MessageIndex
            MessageItem source = new MessageItem("string", "utf-8", "source", true, src, "");
            MessageItem target = new MessageItem("string", "utf-8", "target", true, tgt, "");
            MessageItem operation = new MessageItem("string", "utf-8", "operation", true, op, "");
            MessageItem stamp = new MessageItem("string", "utf-8", "stamp", true, stp, "");
            MessageItem nbrparams = new MessageItem("int", "binaire", "paramCount", true, nbParams, "");
            lsItems.Add(source);
            lsItems.Add(target);
            lsItems.Add(operation);
            lsItems.Add(stamp);
            lsItems.Add(nbrparams);
        }

        //add a parameter to the list 
        public void addParams(String type, String format, String key, object value, String descr)
        {
            lsItems.Add(new MessageItem(type, format, key, false, value, descr));
        }

        public string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Count: " + Count + "\n");
            str.Append("Source: " + Source + "\n");
            str.Append("Target: " + Target + "\n");
            str.Append("Operation: " + Operation + "\n");
            str.Append("Stamp: " + Stamp + "\n");
            str.Append("ParamCount: " + ParamCount + "\n");

            return str.ToString();
        }
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
    }
}
