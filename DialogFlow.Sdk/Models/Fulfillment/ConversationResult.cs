using System.Collections.Generic;
using DialogFlow.Sdk.Models.Common;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Fulfillment
{
    public class ConversationResult
    {
        [JsonProperty("action")]
        public string ActionName { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        [JsonProperty("contexts")]
        public IList<Context> Contexts { get; set; } = new List<Context>();
    }
}