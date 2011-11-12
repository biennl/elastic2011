using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessagesLibrary
{
    public class ServiceMessage : Message
    {
        public List<byte[]> ListParams { get; set; }

        public ServiceMessage(List<byte[]> listParams,String source,String target,String operation,int paramsCount)
            : base()
        {
            base.Operation = operation;
            base.Source = source;
            base.Target = target;
            base.ParamCount = paramsCount;
            this.ListParams = listParams;
        }
    }
}
