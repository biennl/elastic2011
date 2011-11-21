using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace EncodingLibrary
{
    /// <summary>
    ///cette classe permet de coder et decoder des Messages
    /// 
    /// created by: NGUYEN Long Bien && DIALLO Ibrahima Mouctar && Griche Abdelhafid.
    /// </summary>
    public class MsgEncoding : IMessageEncoding
    {
        /// <summary>
        /// Encoding a message to bytes
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        string hache = "";
        public byte[] Encode(ServiceMessage message)
        {

            // msgBytes for calculating the length of message without Count item
            List<byte> messageBytes = new List<byte>();
            // msgBytesFinal including Count item.
            List<byte> messageBytesFinal = new List<byte>();
            UTF8Encoding encoding = new UTF8Encoding();

            //add byte value of Source
            byte[] source = encoding.GetBytes(message.Source);
            messageBytes.AddRange(BitConverter.GetBytes(source.Length));// add count to source item of the message
            messageBytes.AddRange(source);

            //add byte value of Target
            byte[] target = encoding.GetBytes(message.Target);
            messageBytes.AddRange(BitConverter.GetBytes(target.Length));// add count to target item of the message
            messageBytes.AddRange(target);

            //add byte value of operation
            byte[] operation = encoding.GetBytes(message.Operation);
            messageBytes.AddRange(BitConverter.GetBytes(operation.Length));// add count to operation item of the message
            messageBytes.AddRange(operation);

            //add byte value of stamp
            byte[] stamp = encoding.GetBytes(message.Stamp);
            messageBytes.AddRange(BitConverter.GetBytes(stamp.Length));// add count to stamp item of the message
            messageBytes.AddRange(stamp);

            //add byte value of paramCount
            byte[] paramCount = BitConverter.GetBytes(message.ParamCount);
            messageBytes.AddRange(BitConverter.GetBytes(paramCount.Length));// add count to paramCount item of the message
            messageBytes.AddRange(paramCount);


            foreach (string p in message.ListParams)
            {
                messageBytes.AddRange(BitConverter.GetBytes(p.Length));
                byte[] parameter = encoding.GetBytes(p);
                messageBytes.AddRange(parameter);
            }

            message.Count = messageBytes.Count + 4;
            byte[] count = BitConverter.GetBytes(message.Count);

            messageBytesFinal.AddRange(count);
            messageBytesFinal.AddRange(messageBytes);

            // Ajoute au tableau messageBytesFinal le tableau correspondant au message hache
            hache = message.HashMessage(message.ToString());
            byte[] messageHache = encoding.GetBytes(hache);
            messageBytesFinal.AddRange(messageHache);

            return messageBytesFinal.ToArray();
        }

        /// <summary>
        /// decoding bytes to a message
        /// </summary>
        /// <param name="msgBytes"></param>
        /// <returns></returns>
        public ServiceMessage Decode(byte[] msgBytes)
        {
            int index = 0;
            const int INTEGER32_SIZE = 4;
            ServiceMessage message = new ServiceMessage();
            int count = BitConverter.ToInt32(msgBytes, index);
            message.Count = count;
            index = index + INTEGER32_SIZE;

            UTF8Encoding decoding = new UTF8Encoding();
            //read source
            int countSource = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string source = decoding.GetString(msgBytes, index, countSource);
            message.Source = source;
            index = index + countSource;

            //read target
            int countTarget = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string target = decoding.GetString(msgBytes, index, countTarget);
            message.Target = target;
            index = index + countTarget;

            //read operation
            int countOperation = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string operation = decoding.GetString(msgBytes, index, countOperation);
            message.Operation = operation;
            index = index + countOperation;

            //read stamp
            int countStamp = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string stamp = decoding.GetString(msgBytes, index, countStamp);
            message.Stamp = stamp;
            index = index + countStamp;

            //read paramCount
            int countParam = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            int paramCount = BitConverter.ToInt32(msgBytes, index);
            message.ParamCount = paramCount;
            index = index + INTEGER32_SIZE;

            //read list of param
            for (int i = 0; i < paramCount; i++)
            {
                int countParami = BitConverter.ToInt32(msgBytes, index);
                index = index + INTEGER32_SIZE;
                string parami = decoding.GetString(msgBytes, index, countParami);
                message.ListParams.Add(parami);
                index = index + countParami;
            }
            // récupere le message hache (algo MD5) envoyé depuis la couche NetworkLibrarymessageBytesFinal
            string MessageHacheSent = decoding.GetString(msgBytes, msgBytes.Length - 32, 32);

            // Hache le message construit maintenant 
            string MessageHacheControl = message.HashMessage(message.ToString());
            // on enleve 32 bytes (Corespondant a la longueur du message hache) pour le message Hache
            //Comparer le Hache envoyé avec le haché construit
            if (message.Count == msgBytes.Length - 32 && MessageHacheControl == MessageHacheSent)
            {
                return message;
            }
            else
            {
                throw new Exception("Message Decoding error! ");
            }

        }
    }
}
