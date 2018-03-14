using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class IntentModificationResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("status")]
        public IntentStatus Status { get; set; }
    }

    public class IntentStatus
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
