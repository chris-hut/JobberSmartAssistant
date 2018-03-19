using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public interface IMessage
    {
        
    }
    
    public class Message<T> : IMessage
    {
        [JsonProperty("type")]
        public T Type { get; }

        public Message(T type)
        {
            Type = type;
        }
    }
}