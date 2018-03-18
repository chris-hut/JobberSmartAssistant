using System.Collections.Generic;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Jobs;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class JobsResponse
    {
        [JsonProperty("jobs")]
        public IEnumerable<Job> Jobs { get; set; }
    }
}
