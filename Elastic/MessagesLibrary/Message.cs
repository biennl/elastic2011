using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{

    public class Message: IMessage
    {
        private int count;
   

        public string Source { get; set; }
        public string Target { get; set; }
        public string Operation { get; set; }
        public string Stamp { get; set; }
        public int ParamCount { get; set; }
        //to do : liste des params 

        public Message()
        { }
        

        public int getCount()
        {
            return this.count;
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
