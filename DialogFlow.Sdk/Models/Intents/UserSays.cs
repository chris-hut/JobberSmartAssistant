using System.Collections.Generic;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Intents
{
    public class UserSays
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("data")]
        public IList<IConversationData> Data { get; set; } = new List<IConversationData>();
    }

    public interface IConversationData { }
    
    public class TextData : IConversationData 
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class EntityData : IConversationData
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("meta")]
        public string Meta { get; set; }
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("userDefined")]
        public bool UserDefined;
    }

}