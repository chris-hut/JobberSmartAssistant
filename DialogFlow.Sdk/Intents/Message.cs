namespace DialogFlow.Sdk.Intents
{
    public class Message
    {
        public int Type { get; }

        public Message(int type)
        {
            Type = type;
        }
    }
}