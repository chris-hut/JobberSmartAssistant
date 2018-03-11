namespace DialogFlow.Sdk.Intents.Models
{
    public class IntentMessage
    {
        public int Type { get; }

        public IntentMessage(int type)
        {
            Type = type;
        }
    }
}