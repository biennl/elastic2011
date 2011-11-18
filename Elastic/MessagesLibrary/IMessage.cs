using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    public interface IMessage
    {

        private int count;
        public string Source { get; set; }
        public string Target { get; set; }
        public string Operation { get; set; }
        public string Stamp { get; set; }
        public int ParamCount { get; set; }
        public List<string> ListParams { get; set; }

       string ToString();
       int Count;
    }
}
