using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;
using System.Linq;

namespace Jobber.Sdk.Responses
{
    public class VisitsResponse
    {
        [JsonProperty("visits")]
        public IEnumerable<Visit> Visits { get; set; } = new List<Visit>();

        private bool IsEmpty(int i) { return i == 0; }

        public int NumUnassigned => Visits.Where
    }
}