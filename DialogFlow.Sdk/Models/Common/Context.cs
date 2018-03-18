using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Common
{
    public class Context
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("lifespan")]
        public int Lifespan { get; set; }
        [JsonProperty("parameters")]
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
    }
}