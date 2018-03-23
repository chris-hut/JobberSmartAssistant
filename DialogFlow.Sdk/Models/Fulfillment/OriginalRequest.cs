using Newtonsoft.Json;
using System.Collections.Generic;

namespace DialogFlow.Sdk.Models.Fulfillment
{
    public class OriginalRequest
    {
        [JsonProperty("data")]
        public RequestData Data { get; set; }
    }

    public class RequestData
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("Inputs")]
        public IEnumerable<Inputs> Inputs { get; set; }
    }
    
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }

    public class Inputs
    {
        [JsonProperty("rawInputs")]
        public IEnumerable<RawInputs> RawInputs { get; set; }
    }

    public class RawInputs
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}