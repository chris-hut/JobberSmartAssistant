using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public class SpeechMessage : Message<int>
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }
        
        public SpeechMessage() : base(0) {}
    }
}