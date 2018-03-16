using System.Collections.Generic;
using Jobber.Sdk.Models;
using Newtonsoft.Json;

namespace Jobber.Sdk.Responses
{
    public class ExpensesResponse
    {
        [JsonProperty("expenses")]
        public IEnumerable<Expense> Expenses { get; set; } = new List<Expense>();
    }
}