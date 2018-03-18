using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Common
{
    public class Event
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}