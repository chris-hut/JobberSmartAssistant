﻿using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public interface IMessage
    {
        
    }
    
    public class Message : IMessage
    {
        [JsonProperty("type")]
        public int Type { get; }

        public Message(int type)
        {
            Type = type;
        }
    }

    public class GoogleMessage : IMessage
    {
        [JsonProperty("type")]
        public string Type { get; }

        public GoogleMessage(string type)
        {
            Type = type;
        }
    }
}