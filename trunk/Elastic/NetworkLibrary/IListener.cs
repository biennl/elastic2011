using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLibrary
{
    public interface IListener
    {

      ISenderReceiver accept();

      bool pending();
    
    
    }
}
