using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
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