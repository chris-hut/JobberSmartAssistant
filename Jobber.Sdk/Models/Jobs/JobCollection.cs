
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class JobCollection
    {
        [JsonProperty("jobs")] public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
        public int Count => Jobs.Count();
    }
}
