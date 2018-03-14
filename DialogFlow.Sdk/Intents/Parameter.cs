using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dataType")]
        public string DataType { get; set; }
        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("isList")]
        public bool IsList { get; set; }
        [JsonProperty("required")]
        public bool Required { get; set; }
        
        [JsonProperty("prompts")]
        public IList<string> Prompts { get; set; } = new List<string>();
    }
}