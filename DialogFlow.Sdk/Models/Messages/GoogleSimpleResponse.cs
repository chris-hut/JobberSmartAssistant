using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Messages
{
    public class GoogleSimpleResponse : Message<string>
    {
        [JsonProperty("platform")]
        public string Platform { get; } = "google";
        [JsonProperty("textToSpeech")]
        public string Speech { get; set; }

        public GoogleSimpleResponse() : base("simple_response")
        {
        }
    }
}