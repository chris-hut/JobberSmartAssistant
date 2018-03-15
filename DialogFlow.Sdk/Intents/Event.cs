using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class Event
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}