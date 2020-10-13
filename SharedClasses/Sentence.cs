using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClasses
{
    public class Sentence
    {
        public string Sender;
        public string Data;
        public Type MessageType;

        public enum Type
        {
            CHAT_MESSAGE,
            BOT_QUESTION,
            BOT_ANSWER,
            SERVER_MESSAGE,
            BOT_REQUEST
        }

        //public Sentence(string sender, string sentence, Type messageType)
        //{
        //    this.Sender = sender;
        //    this.Data = sentence;
        //    this.MessageType = messageType;
        //}

        public string toString()
        {
            return $"Sentence: SENDER: {this.Sender}, TYPE: {this.MessageType}, DATA: {this.Data}";
        }

        public string[] toWordArray()
        {
            return this.Data.Split(" ");
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
