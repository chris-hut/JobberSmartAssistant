using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Responses;
using Refit;

namespace Jobber.Sdk
{
    public interface IJobberService
    {
        [Post("/jobs")]
        [Headers("X-API-VERSION: 2.0.0")]
        Task<JobsResponse> CreateJobAsync([Body] Job job);

        [Put("/quotes/{quote_id}")]
        Task ModifyQuoteAsync([AliasAs("quote_id")] string quote_Id, [Body] Quote quote);

        [Get("/jobs")]
        [Headers("X-API-VERSION: 2.0.0")]
        Task<JobsResponse> GetJobsAsync();

        [Get("/clients?search={searchQuery}")]
        Task<ClientsResponse> GetClientsAsync([AliasAs("searchQuery")] string searchQuery = "");

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
