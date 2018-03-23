using System.Collections.Generic;
using System.Threading.Tasks;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest.Requests;
using Refit;

namespace Jobber.Sdk.Rest
{
    public interface IJobberApi
    {
        [Post("/jobs")]
        Task<JobCollection> CreateJobAsync([Body] Dictionary<string, CreateJobRequest> createJobRequest);

        [Put("/quotes/{quote_id}")]
        Task UpdateQuoteAsync([AliasAs("quote_id")] string quote_Id, [Body] Dictionary<string, Quote> quote);

        [Get("/jobs")]
        Task<JobCollection> GetJobsAsync();

        [Get("/clients?search={searchQuery}")]
        Task<ClientCollection> GetClientsAsync([AliasAs("searchQuery")] string searchQuery = "");

        [Get("/quotes")]
        Task<QuotesCollection> GetQuotesAsync();

        [Get("/invoices")]
        Task<InvoicesCollection> GetInvoicesAsync();

        [Get("/transactions")]
        Task<TransactionCollection> GetTransactionsAsync();

        [Get("/visits")]
        Task<VisitsCollections> GetVisitsAsync();

        [Get("/visits?where=[start_at>={start},start_at<={end}]")]
        Task<VisitsCollections> GetTodaysVisitsAsync([AliasAs("start")] long start, [AliasAs("end")] long end);

        [Get("/transactions?where=[created_at>={start},created_at<={end}]")]
        Task<TransactionCollection> GetRangedTransactionsAsync([AliasAs("start")] long start, [AliasAs("end")] long end);
    }
}