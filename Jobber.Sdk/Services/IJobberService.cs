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
        Task<JobsResponse> CreateJobAsync([Body] Job job);

        [Put("/quotes/{quote_id}")]
        Task ModifyQuoteAsync([AliasAs("quote_id")] string quote_Id, [Body] Quote quote);

        [Get("/jobs")]
        Task<JobsResponse> GetJobsAsync();

        [Get("/quotes")]
        Task<QuotesResponse> GetQuotesAsync();

        [Get("/invoices")]
        Task<InvoicesResponse> GetInvoicesAsync();

        [Get("/transactions")]
        Task<TransactionsResponse> GetTransactionsAsync();

        [Get("/expenses")]
        Task<ExpensesResponse> GetExpensesAsync();

        [Get("/visits")]
        Task<VisitsResponse> GetVisitsAsync();
    }
}
