using System.Collections.Generic;

namespace Jobber.Sdk.Models
{
    public class QuotesResponse
    {
        public IEnumerable<Quote> Quotes { get; set; } = new List<Quote>();
    }
}