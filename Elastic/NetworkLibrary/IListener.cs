using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLibrary
{
    /// <summary>
    /// Interface représentant un TcpListener permettant d'écouter les connexions entrantes sur le réseau
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// Accepte une connexion entrante
        /// </summary>
        /// <returns> Le ISenderReceiver représentant la socket acceptée</returns>
        ISenderReceiver accept();

        /// <summary>
        /// Détermine s'il y a des connexions entrantes en attente
        /// </summary>
        /// <returns> Un booléen qui retourne vrai s'il y a des connexions entrantes en attente</returns>
        bool pending();

        /// <summary>
        /// Arrête l'écoute du TcpListener
        /// </summary>
        void close();


    }
}
