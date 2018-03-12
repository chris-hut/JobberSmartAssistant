namespace DialogFlow.Sdk.Intents
{
    public class SpeechMessage : Message
    {
        public string Speech { get; set; }
        
        public SpeechMessage() : base(0) {}
    }
}