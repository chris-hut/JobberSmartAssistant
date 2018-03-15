using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Jobber.Sdk.Models
{
    public class Invoice
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("invoice_net")]
        public int InvoiceNet { get; set; }

        [JsonProperty("bad_debt")]
        public bool BadDebt { get; set; }

        [JsonProperty("created_at")]
        public int CreatedAt { get; set; }

        [JsonProperty("issued_date")]
        public int IssuedDate { get; set; }

        [JsonProperty("due_date")]
        public int DueDate { get; set; }

        [JsonProperty("received_date")]
        public int RecievedDate { get; set; }

        [JsonProperty("updated_at")]
        public int UpdateedAt { get; set; }

        [JsonProperty("client")]
        public Client MyClient { get; set; }


    }
}
