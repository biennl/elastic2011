using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessagesLibrary;

namespace EncodingLibrary
{
    /// <summary>
    /// Object encode and decode messages
    /// 
    /// created by: NGUYEN Long Bien && DIALLO Ibrahima Mouctar.
    /// </summary>
    public class MsgEncoding : IEncoding
    {
        /// <summary>
        /// Encoding a message to bytes
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] Encode(Message msg)
        {
            List<byte> msgBytes = new List<byte>();
            UTF8Encoding encoding = new UTF8Encoding();
            
            //add byte value of Count
            byte[] count = BitConverter.GetBytes(msg.Count);
            msgBytes.AddRange(count);

            //add byte value of Source
            byte[] source = encoding.GetBytes(msg.Source);
            msgBytes.AddRange(BitConverter.GetBytes(source.Length));// add count to source item of the message
            msgBytes.AddRange(source);

            //add byte value of Target
            byte[] target = encoding.GetBytes(msg.Target);
            msgBytes.AddRange(BitConverter.GetBytes(target.Length));// add count to target item of the message
            msgBytes.AddRange(target);

            //add byte value of operation
            byte[] operation = encoding.GetBytes(msg.Operation);
            msgBytes.AddRange(BitConverter.GetBytes(operation.Length));// add count to operation item of the message
            msgBytes.AddRange(operation);

            //add byte value of stamp
            byte[] stamp = encoding.GetBytes(msg.Stamp);
            msgBytes.AddRange(BitConverter.GetBytes(stamp.Length));// add count to stamp item of the message
            msgBytes.AddRange(stamp);

            //add byte value of paramCount
            byte[] paramCount = BitConverter.GetBytes(msg.ParamCount);
            msgBytes.AddRange(BitConverter.GetBytes(paramCount.Length));// add count to paramCount item of the message
            msgBytes.AddRange(paramCount);

            if (msg is CatalogMessage)
            {
                CatalogMessage msgC = (CatalogMessage)msg;
                foreach (string p in msgC.ListParams)
                {
                    msgBytes.AddRange(BitConverter.GetBytes(p.Length));
                    byte[] param = encoding.GetBytes(p);
                    msgBytes.AddRange(param);
                }
            }
            else if (msg is ServiceMessage)
            {
                ServiceMessage Smsg = (ServiceMessage)msg;
                foreach (byte[] p in Smsg.ListParams)
                {
                    msgBytes.AddRange(BitConverter.GetBytes(p.Length));
                    msgBytes.AddRange(p);
                }                
            }
            else if ( msg is ErrorMessage )
            {
                ErrorMessage msgE = (ErrorMessage)msg;
                msgBytes.AddRange(BitConverter.GetBytes(msgE.ErrorMessage.Length));
                msgBytes.AddRange(encoding.GetBytes(msgE.ErrorMessage));
            }
            return msgBytes.ToArray();
        }

        /// <summary>
        /// decoding bytes to a message
        /// </summary>
        /// <param name="msgBytes"></param>
        /// <returns></returns>
        public Message Decode(byte[] msgBytes)
        {
            int index = 0;
            const int INTEGER32_SIZE = 4;
            Message msg = new Message();
            int count = BitConverter.ToInt32(msgBytes, index);
            msg.Count = count;
            index = index + INTEGER32_SIZE;

            UTF8Encoding decoding = new UTF8Encoding();
            //read source
            int countSource = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string source = decoding.GetString(msgBytes, index, countSource);
            msg.Source = source;
            index = index + countSource;

            //read target
            int countTarget = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string target = decoding.GetString(msgBytes, index, countTarget);
            msg.Target = target;
            index = index + countTarget;

            //read operation
            int countOperation = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string operation = decoding.GetString(msgBytes, index, countOperation);
            msg.Operation = operation;
            index = index + countOperation;

            //read stamp
            int countStamp = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            string stamp = decoding.GetString(msgBytes, index, countStamp);
            msg.Stamp = stamp;
            index = index + countStamp;

            //read paramCount
            int countParam = BitConverter.ToInt32(msgBytes, index);
            index = index + INTEGER32_SIZE;
            int paramCount = BitConverter.ToInt32(msgBytes, index);
            msg.ParamCount = paramCount;
            index = index + INTEGER32_SIZE;


            return msg;
        }
    }
}
