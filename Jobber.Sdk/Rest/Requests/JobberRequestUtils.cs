using System.Collections.Generic;

namespace Jobber.Sdk.Rest.Requests
{
    public static class JobberRequestUtils
    {
        public static Dictionary<string, T> CreateRequestBodyFor<T>(string requestType, T body)
        {
            return new Dictionary<string, T>
            {
                { requestType, body }
            };
        }
    }
}