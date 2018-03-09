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
        Task<JobberModificationResponse> GetJobs();

        [Get("/quotes")]
        Task<JobberModificationResponse> GetQuotes();

        [Get("/invoices")]
        Task<JobberModificationResponse> GetInvoices();

        [Get("/transactions")]
        Task<JobberModificationResponse> GetTransactions();

        [Get("/expenses")]
        Task<JobberModificationResponse> GetExpenses();

        [Get("/visits")]
        Task<JobberModificationResponse> GetVisits();



    }
}
