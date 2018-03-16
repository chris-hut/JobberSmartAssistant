using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class JobsResponse
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}
