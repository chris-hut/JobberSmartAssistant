using System;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Fulfillment
{
    public class FulfillmentRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("lang")]
        public string Language { get; set; }
    }
}