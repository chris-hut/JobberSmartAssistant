using System.Collections.Generic;

namespace DialogFlow.Sdk.Intents
{
    public class UserSays
    {
        public int Count { get; set; }
        public IEnumerable<IUserSaysData> Data { get; set; } = new List<IUserSaysData>();
    }

    public interface IUserSaysData { }
    
    public class TextData : IUserSaysData 
    {
        public string Text { get; set; }
    }

    public class EntityData : IUserSaysData
    {
        public string Text { get; set; }
        public string Meta { get; set; }
        public string Alias { get; set; }
        public bool UserDefined;
    }

}