using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class IntentStatusResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("status")]
        public IntentStatus Status { get; set; }

        public string ErrorMessage => $"{Status.ErrorType}; {Status.ErrorDetails}";
    }

    public class IntentStatus
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("errorType")]
        public string ErrorType { get; set; }
        [JsonProperty("errorDetails")]
        public string ErrorDetails { get; set; }
    }
}
