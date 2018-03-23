using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Jobber.Sdk.Models.Financials
{
    public class TransactionCollection
    {
        [JsonProperty("transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }

        public double GetTotal()
        {
            return Transactions.Sum(transaction => transaction.GetAmountValue());
        }
    }
}