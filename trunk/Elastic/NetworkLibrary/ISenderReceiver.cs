using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLibrary
{
    /// <summary>
    /// Interface représentant une socket permettant de recevoir et d'envoyer des données
    /// </summary>
    public interface ISenderReceiver
    {
        /// <summary>
        /// Envoie des données spécifiées par le paramètre <paramref name="bytes" />
        /// </summary>
        /// <param name="bytes"></param>
        void send(byte[] bytes);
        
        /// <summary>
        /// Reçoit les données disponibles sur la socket
        /// </summary>
        /// <returns>Un tableau de bytes représentant les données disponibles sur la socket</returns>
        byte[] receive();
        
        /// <summary>
        /// Détermine le nombre de bytes disponible sur la socket
        /// </summary>
        /// <returns>Le nombre de bytes disponible sur la socket</returns>
        int available();

        /// <summary>
        /// Ferme la connexion établie par la socket
        /// </summary>
        void close();
    }
}
