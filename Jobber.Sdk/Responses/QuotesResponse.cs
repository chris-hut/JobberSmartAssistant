using System.Collections.Generic;
using Jobber.Sdk.Models;

namespace Jobber.Sdk.Responses
{
    public class QuotesResponse
    {
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();
    }
}