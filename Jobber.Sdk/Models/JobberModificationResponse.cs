using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class JobberModificationResponse
    {
        public string Id { get; set; }
        public JobberStatus Status { get; set; }


        public List<Job> Jobs { get; set; }

        public List<Quote> Quotes { get; set; }

        public List<Invoice> Invoices { get; set; }

        public List<Transaction> Transactions { get; set; }

        public List<Expense> Expenses { get; set; }

        public List<Visit> Vists { get; set; }


    }

    public class JobberStatus
    {
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
