using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
{
    public class UserSays
    {
        public int Count { get; set; }
        public IList<IConversationData> Data { get; set; } = new List<IConversationData>();
    }

    public interface IConversationData { }
    
    public class TextData : IConversationData 
    {
        public string Text { get; set; }
    }

    public class EntityData : IConversationData
    {
        public string Text { get; set; }
        public string Meta { get; set; }
        public string Alias { get; set; }
        public bool UserDefined;
    }

}