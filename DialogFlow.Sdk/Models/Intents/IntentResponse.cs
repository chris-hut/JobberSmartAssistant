using System.Collections.Generic;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Messages;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Intents
{
    public class IntentResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("defaultResponsePlatforms")]
        public Dictionary<string, bool> DefaultResponsePlatforms { get; set; } = new Dictionary<string, bool>();
        [JsonProperty("parameters")]
        public IList<Parameter> Parameters { get; set; } = new List<Parameter>();
        [JsonProperty("messages")]
        public IList<Message> Messages { get; set; } = new List<Message>();
        [JsonProperty("affectedContexts")]
        public IList<Context> AffectedContexts { get; set; } = new List<Context>();
    }
}
