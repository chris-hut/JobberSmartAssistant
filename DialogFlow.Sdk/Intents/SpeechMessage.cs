using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class SpeechMessage : Message
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }
        
        public SpeechMessage() : base(0) {}
    }
}