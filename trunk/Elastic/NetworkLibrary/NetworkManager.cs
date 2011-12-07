using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace NetworkLibrary
{
    /// <summary>
    /// Factory permettant d'instancier des Tcplistener et des ISenderReceiver
    /// </summary>
    public class NetworkManager
    {
        /// <summary>
        /// La liste des Listener permettant d'accepter des connexions entrantes
        /// </summary>
        private List<Listener> listnerList;

        public NetworkManager()
        {
            listnerList = new List<Listener>();
        }

        /// <summary>
        /// Instancie un Listener. Si le Listener paramétré existe déjà, renvoie le listener correspondant
        /// </summary>
        /// <param name="adress">L'adresse ip du listener</param>
        /// <param name="port">Le port d'écoute du Listener</param>
        /// <returns></returns>
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

        /// <summary>
        /// Instancie un SenderReceiver
        /// </summary>
        /// <param name="adress">L'adresse ip du SenderReceiver</param>
        /// <param name="port">Le port d'écoute de la socket</param>
        /// <returns></returns>
        public ISenderReceiver createSenderReceiver(string adress, int port)
        {

            return new SenderReceiver(adress, port);
        
        }


    }
}
