using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents.Models
{
    public class Intent
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool Auto { get; set; }
        public bool FallbackIntent { get; set; }
        public bool ResetsContext { get; set; }
        public bool WebhookUsed { get; set; }
        public bool WebhookForSlotFilling { get; set; }

        public int Priority { get; set; } = 1;

        public IEnumerable<string> Event { get; set; } = new List<string>();
        public IEnumerable<UserSays> UserSays { get; set; } = new List<UserSays>();
        public IEnumerable<string> Contexts { get; set; } = new List<string>();
        public IEnumerable<string> Templates { get; set; } = new List<string>();
        public IEnumerable<IntentResponse> Responses { get; set; } = new List<IntentResponse>();
    }
}
