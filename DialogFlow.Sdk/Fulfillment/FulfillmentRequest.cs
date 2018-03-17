using System;
using System.Linq;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Fulfillment
{
    public class FulfillmentRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("lang")]
        public string Language { get; set; }
        [JsonProperty("result")]
        public ConversationResult ConversationResult { get; set; }
        [JsonProperty("originalRequest")]
        public OriginalRequest OriginalRequest { get; set; }

        public bool IsForAction(string actionName)
        {
            return actionName.ToLower().Equals(ConversationResult.ActionName.ToLower());
        }

        public string GetParameter(string parameterName)
        {
            return ConversationResult.Parameters[parameterName];
        }

        public int GetParameterAsInt(string parameterName)
        {
            return int.Parse(GetParameter(parameterName));
        }

        public DateTime GetParameterAsDateTime(string parameterName)
        {
            return DateTime.Parse(GetParameter(parameterName));
        }
        
        public string GetContextParameter(string contextName, string parameterName)
        {
            return ConversationResult.Contexts
                .First(c => c.Name == contextName)
                .Parameters[parameterName];
        }

        public int GetContextParameterAsInt(string contextName, string parameterName)
        {
            return int.Parse(GetContextParameter(contextName, parameterName));
        }

        public DateTime GetContextParameterAsDateTime(string contextName, string parameterName)
        {
            return DateTime.Parse(GetContextParameter(contextName, parameterName));
        }
    }
}