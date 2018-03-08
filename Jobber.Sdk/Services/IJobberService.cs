using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Refit;

namespace Jobber.Sdk.Services
{
    public interface IJobberService
    {
        [Post("/jobs")]
        Task<JobberModificationResponse> CreateJob([Body] Job job);

        [Put("/quotes/{quote_id}")]
        Task<JobberModificationResponse> ModifyQuote([AliasAs("quote_id")] string quote_Id, [Body] Quote quote);

        [Get("/jobs")]
        Task<JobberModificationResponse> GetJobs([Body] Job job);

        [Get("/quotes")]
        Task<JobberModificationResponse> GetQuotes([Body] Quote quote);

        [Get("/invoices")]
        Task<JobberModificationResponse> GetInvoices([Body] Invoice invoice);

        [Get("/transactions")]
        Task<JobberModificationResponse> GetTransactions([Body] Transaction transaction);

        [Get("/expenses")]
        Task<JobberModificationResponse> GetExpenses([Body] Expense expense);

        [Get("/visits")]
        Task<JobberModificationResponse> GetVisits([Body] Visit visit);



    }
}
