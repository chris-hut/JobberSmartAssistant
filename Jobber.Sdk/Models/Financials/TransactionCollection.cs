using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Financials
{
    public class TransactionCollection
    {
        [JsonProperty("transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}