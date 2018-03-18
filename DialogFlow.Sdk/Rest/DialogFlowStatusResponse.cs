using Newtonsoft.Json;

namespace DialogFlow.Sdk.Rest
{
    public class DialogFlowStatusResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("status")]
        public Status Status { get; set; }

        public string ErrorMessage => $"{Status.ErrorType}; {Status.ErrorDetails}";
    }

    public class Status
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("errorType")]
        public string ErrorType { get; set; }
        [JsonProperty("errorDetails")]
        public string ErrorDetails { get; set; }
    }
}
