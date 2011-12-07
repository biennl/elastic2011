using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkLibrary
{

    /// <summary>
    /// Classe représentant un TcpListener permettant d'écouter les connexions entrantes sur le réseau
    /// </summary>
    class Listener : IListener
    {

        public TcpListener tcpListener { get; set; }
        public string adress { get; set; }
        public int port { get; set; }

        public Listener(string adress, int port)
        {
            this.adress = adress;
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(adress), port);
            this.tcpListener.Start();
        }

        /// <summary>
        /// Accepte une connexion entrante
        /// </summary>
        /// <returns> Le ISenderReceiver représentant la socket acceptée</returns>
        public ISenderReceiver accept()
        {
            return (ISenderReceiver)(new SenderReceiver(this.tcpListener.AcceptSocket()));
        }

        /// <summary>
        /// Détermine s'il y a des connexions entrantes en attente
        /// </summary>
        /// <returns> Un booléen qui retourne vrai s'il y a des connexions entrantes en attente</returns>
        public bool pending()
        {
            return this.tcpListener.Pending();
        }

        /// <summary>
        /// Arrête l'écoute du TcpListener
        /// </summary>
        public void close()
        {
            tcpListener.Stop();
        }

    }
}
