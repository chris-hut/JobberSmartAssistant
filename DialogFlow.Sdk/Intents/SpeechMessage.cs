namespace DialogFlow.Sdk.Intents.Models
{
    public class SpeechMessage : IntentMessage
    {
        public string Speech { get; set; }
        
        public SpeechMessage() : base(0) {}
    }
}