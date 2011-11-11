using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class FactrorySocketServices
    {

        public static SocketServices create()
        {

            return Utils.getInstance();

        }


    }
}
