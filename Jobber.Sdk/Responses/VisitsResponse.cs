using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class VisitsResponse
    {
        public IEnumerable<Visit> Visits { get; set; } = new List<Visit>();
    }
}