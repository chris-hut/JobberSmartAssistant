using Newtonsoft.Json;

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
    }
    
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}