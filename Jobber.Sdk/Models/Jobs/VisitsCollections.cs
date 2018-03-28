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
        public int Count => Visits.Count(visit => visit.IsAssigned());
        public int NumCompletable => Visits.Count(v => v.Completable);
        public IEnumerable<Visit> CompletableVisits => Visits.Where(v => v.Completable);
    }
}