using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClass
{
    public class Sentence
    {
        public string Sender;
        public string Data;
        public Type MessageType;

        public enum Type
        {
            CHAT_MESSAGE,
            SERVER_MESSAGE,
            DISCONNECT,
            USERSMESSAGE,
            BOT_REQUEST,
            DISCONNECT_REQUEST
        }

        public string toString()
        {
            return $"Sentence: SENDER: {this.Sender}, TYPE: {this.MessageType}, DATA: {this.Data}";
        }

        public Type getMessageType()
        {
            return this.MessageType;
        }

        public string getSender()
        {
            return this.Sender;
        }

        public string getData()
        {
            return this.Data;
        }
    }
}
