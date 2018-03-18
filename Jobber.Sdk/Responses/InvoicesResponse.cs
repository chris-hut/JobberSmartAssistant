using System.Collections.Generic;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Financials;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class InvoicesResponse
    {
        [JsonProperty("invoices")]
        public IEnumerable<Invoice> Invoices = new List<Invoice>();
    }
}