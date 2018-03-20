using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Fulfillment
{
    public class GoogleFulfillmentData : IFulfillmentData
    {
        [JsonProperty("expectUserResponse")]
        public bool ExpectsUserResponse { get; set; }

        public static GoogleFulfillmentData MarkEndOfConversation => new GoogleFulfillmentData
        {
            ExpectsUserResponse = false
        };
    }
}