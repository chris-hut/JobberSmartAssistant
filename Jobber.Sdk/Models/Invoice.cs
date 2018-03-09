using System;
using System.Collections.Generic;
using System.Text;

namespace Jobber.Sdk.Models
{
    public class Invoice
    {

        public int Id { get; set; }

        public string Subject { get; set; }

        public int Total { get; set; }

        public int InvoiceNet { get; set; }

        public bool BadDebt { get; set; }

        public int CreatedAt { get; set; }

        public int IssuedDate { get; set; }

        public int DueDate { get; set; }

        public int RecievedDate { get; set; }

        public int Client { get; set; }


    }
}
