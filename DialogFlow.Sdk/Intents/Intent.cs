using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
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

        public IList<string> Event { get; set; } = new List<string>();
        public IList<UserSays> UserSays { get; set; } = new List<UserSays>();
        public IList<string> Contexts { get; set; } = new List<string>();
        public IList<string> Templates { get; set; } = new List<string>();
        public IList<IntentResponse> Responses { get; set; } = new List<IntentResponse>();
    }
}
