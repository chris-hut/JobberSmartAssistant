using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models.Financials
{
    public class ExpenseCollection
    {
        [JsonProperty("expenses")]
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
    }
}