using System.Collections.Generic;

namespace Jobber.Sdk.Models
{
    public class VisitsResponse
    {
        public IEnumerable<Visit> Visits { get; set; } = new List<Visit>();
    }
}