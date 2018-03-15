using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Intents
{
    public class Intent
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("auto")]
        public bool Auto { get; set; }
        [JsonProperty("fallbackIntent")]
        public bool FallbackIntent { get; set; }
        [JsonProperty("resetsContext")]
        public bool ResetsContext { get; set; }
        [JsonProperty("webhookUsed")]
        public bool WebhookUsed { get; set; }
        [JsonProperty("webhookForSlotFilling")]
        public bool WebhookForSlotFilling { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; } = 500000;

        [JsonProperty("event")]
        public IList<string> Events { get; set; } = new List<string>();
        
        [JsonProperty("userSays")]
        public IList<UserSays> UserSays { get; set; } = new List<UserSays>();
        [JsonProperty("contexts")]
        public IList<string> Contexts { get; set; } = new List<string>();
        [JsonProperty("templates")]
        public IList<string> Templates { get; set; } = new List<string>();
        [JsonProperty("responses")]
        public IList<IntentResponse> Responses { get; set; } = new List<IntentResponse>();
    }
}
