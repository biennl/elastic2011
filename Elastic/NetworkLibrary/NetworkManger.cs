using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace NetworkLibrary
{
    public class NetworkManager
    {
              
        private List<Listener> listnerList;

        public NetworkManager()
        {
            listnerList = new List<Listener>();
        }

        public IListener createListner(string adress, int port)
        {
            Listener l;
            for (int i = 0; i < listnerList.Count; i++) 
            {

                l = listnerList[i];
                if ((l.port == port) && (l.adress == adress)) return l;
            }
            l = new Listener(adress, port);
            listnerList.Add(l);

            return l;
        
        }

        public ISenderReceiver createSenderReceiver(string adress, int port)
        {

            return new SenderReceiver(adress, port);
        
        }


    }
}
