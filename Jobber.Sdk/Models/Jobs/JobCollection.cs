using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class JobCollection
    {
        [JsonProperty("jobs")]
        public IEnumerable<Job> Jobs { get; set; }
    }
}
