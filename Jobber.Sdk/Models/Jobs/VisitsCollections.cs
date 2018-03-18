using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Jobs
{
    public class VisitsCollections
    {
        [JsonProperty("visits")]
        public IEnumerable<Visit> Visits { get; set; } = new List<Visit>();

        public int NumUnassigned => Visits.Count(visit => visit.NotAssigned());
    }
}