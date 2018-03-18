using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public class Message
    {
        [JsonProperty("type")]
        public int Type { get; }

        public Message(int type)
        {
            Type = type;
        }
    }
}