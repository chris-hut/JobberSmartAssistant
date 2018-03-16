using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jobber.Sdk.Responses
{
    public class TransactionsResponse
    {
        [JsonProperty("transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}