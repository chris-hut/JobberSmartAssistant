namespace DialogFlow.Sdk.Intents.Models
{
    public class IntentModificationResponse
    {
        public string Id { get; set; }
        public IntentStatus Status { get; set; }
    }

    public class IntentStatus
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
