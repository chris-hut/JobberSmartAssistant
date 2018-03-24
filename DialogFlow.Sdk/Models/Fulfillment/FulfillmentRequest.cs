using System;
using System.Linq;
using System.Runtime.CompilerServices;
using DialogFlow.Sdk.Models.Common;
using Newtonsoft.Json;

namespace DialogFlow.Sdk.Models.Fulfillment
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

        public bool DoesRequestingDeviceHaveAScreen()
        {
            return ConversationResult.Contexts.Any(c => c.Name == "actions_capability_screen_output");
        }

        public string GetParameter(string parameterName, string defaultValue = null)
        {
            try
            {
                return ConversationResult.Parameters[parameterName];
            }
            catch
            {
                return defaultValue;
            }
        }

        public int GetParameterAsInt(string parameterName)
        {
            return int.Parse(GetParameter(parameterName));
        }
        
        public bool IsParameterDateRange(string parameter)
        {
            return DateTimeRange.IsParsable(GetParameter(parameter));
        }
        
        public DateTime GetParameterAsDateTime(string parameterName)
        {
            return DateTime.Parse(GetParameter(parameterName));
        }

        public DateTimeRange GetParemterAsDateTimeRange(string parameterName)
        {
            return DateTimeRange.Parse(GetParameter(parameterName));
        }
        
        public string GetContextParameter(string contextName, string parameterName)
        {
            return ConversationResult.Contexts
                .First(c => c.Name.ToLower() == contextName.ToLower())
                .Parameters[parameterName];
        }

        public int GetContextParameterAsInt(string contextName, string parameterName)
        {
            return int.Parse(GetContextParameter(contextName, parameterName));
        }

        public bool IsContextParameterDateRange(string contextName, string parameter)
        {
            return DateTimeRange.IsParsable(GetContextParameter(contextName, parameter));
        }

        public DateTime GetContextParameterAsDateTime(string contextName, string parameterName)
        {
            return DateTime.Parse(GetContextParameter(contextName, parameterName));
        }

        public DateTimeRange GetContextParameterAsDateTimeRange(string contextName, string parameterName)
        {
            return DateTimeRange.Parse(GetContextParameter(contextName, parameterName));
        }

        public T GetContextParameterAs<T>(string contextName, string paramerterName)
        {
            var rawParameter = GetContextParameter(contextName, paramerterName);
            return JsonConvert.DeserializeObject<T>(rawParameter);
        }
    }
}