using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;

namespace MessagesLibrary
{
    /// <summary>
    /// represente la structure de données lier au message
    /// et la fonction de calcul de hash du message
    /// </summary>
    public class Message : IMessage
    {

        private int count;
        public string Source { get; set; }
        public string Target { get; set; }
        public string Operation { get; set; }
        public string Stamp { get; set; }
        public int ParamCount { get; set; }
        public List<string> ListParams { get; set; }
        
        /// <summary>
        /// construction par défaut
        /// </summary>
        public Message()
        {
            this.ListParams = new List<string>();
        }

        /// <summary>
        /// constructeur avec parametres
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        /// <param name="Operation"></param>
        /// <param name="Stamp"></param>
        /// <param name="ParamCount"></param>
        public Message(string Source, string Target, string Operation, string Stamp, int ParamCount)
        {
            this.Source = Source;
            this.Target = Target;
            this.Operation = Operation;
            this.Stamp = Stamp;
            this.ParamCount = ParamCount;
            this.ListParams = new List<string>();

        }

        /// <summary>
        /// affiche les propriétés du message
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Count: " + Count + "\n");
            str.Append("Source: " + Source + "\n");
            str.Append("Target: " + Target + "\n");
            str.Append("Operation: " + Operation + "\n");
            str.Append("Stamp: " + Stamp + "\n");
            str.Append("ParamCount: " + ParamCount + "\n");

            return str.ToString();
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        /// <summary>
        /// calcule le hash du message
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public string HashMessage(string stringToHash)
        {

            MD5 md5HashAlgo = MD5.Create();

            // Place le texte à hacher dans un tableau d'octets 
            byte[] byteArrayToHash = Encoding.UTF8.GetBytes(stringToHash);

            // Hash le texte et place le résulat dans un tableau d'octets 
            byte[] hashResult = md5HashAlgo.ComputeHash(byteArrayToHash);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hashResult.Length; i++)
            {
                // Affiche le Hash en hexadecimal 
                result.Append(hashResult[i].ToString("X2"));
            }

            return result.ToString();
            
        }


    }
}
