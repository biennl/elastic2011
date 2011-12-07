using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkLibrary
{
    /// <summary>
    /// Interface représentant une socket permettant de recevoir et d'envoyer des données
    /// </summary>
    class SenderReceiver : ISenderReceiver
    {

        private Socket senderReceiver;

        public SenderReceiver(Socket socket)
        {
            this.senderReceiver = socket;
        }

        public SenderReceiver(string host, int port)
        {
            this.senderReceiver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress[] address = Dns.GetHostAddresses(host);
            senderReceiver.Connect(address, port);
        }

        /// <summary>
        /// Envoie des données spécifié par le paramètre <paramref name="bytes" />
        /// </summary>
        /// <param name="bytes"></param>
        public void send(byte[] bytes)
        {
            if (this.senderReceiver == null)
            {
                throw new SystemException("La socket a été fermée");
            }
            //int offset = 0;
            //while (offset < bytes.Length)
            //{
            //    int sent = this.senderReceiver.Send(bytes, offset, bytes.Length - offset, SocketFlags.None);
            //    offset += sent;
            //}
            senderReceiver.Send(bytes, SocketFlags.None);
        }

        /// <summary>
        /// Reçoit toutes les données disponibles sur la socket
        /// </summary>
        /// <returns>Un tableau de bytes représentant les données disponibles sur la socket</returns>
        public byte[] receive()
        {
            byte[] messageCount =receive(4);
            int count = BitConverter.ToInt32(messageCount, 0);

            byte[] messageBytes = receive(count - 4);
            List<Byte> listBytesMessage = new List<byte>();
            listBytesMessage.AddRange(messageCount);
            listBytesMessage.AddRange(messageBytes);
            
            // Reception d'un tableau de Byte correspondant au 
            // message hache avec la fonction MD5
            byte[] HachMessageBytes=receive(32);
            listBytesMessage.AddRange(HachMessageBytes);


            return listBytesMessage.ToArray();

        }

        /// <summary>
        /// Receive datas specified by the parameter <paramref name="count" />
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private byte[] receive(int count)
        {
            if (this.senderReceiver == null)
            {
                throw new SystemException("La socket a été fermée");
            }
            byte[] bytes = new byte[count];
            int offset = 0;
            while (offset < count)
            {
                int received = senderReceiver.Receive(bytes, offset, count - offset, SocketFlags.None);
                if (received == 0) throw new SystemException("Socket déconnectée");
                offset += received;
            }
            return bytes;
        }

        /// <summary>
        /// Détermine le nombre de bytes disponible sur la socket
        /// </summary>
        /// <returns>Le nombre de bytes disponible sur la socket</returns>
        public int available()
        {
            return this.senderReceiver.Available;
        }

        /// <summary>
        /// Closes the connexion
        /// </summary>
        public void close()
        {
            if (this.senderReceiver == null)
            {
                throw new SystemException("La socket a déjà été fermée");
            }
            this.senderReceiver.Shutdown(SocketShutdown.Both);
            this.senderReceiver.Close();
        }

    }
}
