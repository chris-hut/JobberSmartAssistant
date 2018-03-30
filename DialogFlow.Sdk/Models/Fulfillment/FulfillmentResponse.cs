using System.Collections.Generic;
using System.Linq;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Fulfillment
{
    public class FulfillmentResponse
    {
        [JsonProperty("speech")]
        public string Speech { get; set; }
        [JsonProperty("displayText")]
        public string DisplayText { get; set; }
        [JsonProperty("contextOut")]
        public List<Context> ContextOut { get; set; } = new List<Context>();
        [JsonProperty("messages")]
        public IList<IMessage> Messages { get; set; } = new List<IMessage>();
        [JsonProperty("data")]
        public Dictionary<string, IFulfillmentData> Data { get; set; } = new Dictionary<string, IFulfillmentData>();

        public Context GetContext(string contextName)
        {
            return ContextOut.First(c => c.Name.ToLower() == contextName.ToLower());
        }
    }

    public interface IFulfillmentData
    {
        
    }
}