using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Refit;

namespace Jobber.Sdk
{
    public interface IJobberService
    {
        [Post("/jobs")]
        [Headers("X-API-VERSION: 2.0.0")]
        Task<JobCollection> CreateJobAsync([Body] Job job);

        [Put("/quotes/{quote_id}")]
        Task ModifyQuoteAsync([AliasAs("quote_id")] string quote_Id, [Body] Quote quote);

        [Get("/jobs")]
        [Headers("X-API-VERSION: 2.0.0")]
        Task<JobCollection> GetJobsAsync();

        [Get("/clients?search={searchQuery}")]
        Task<ClientCollection> GetClientsAsync([AliasAs("searchQuery")] string searchQuery = "");

        [Get("/quotes")]
        Task<QuotesCollection> GetQuotesAsync();

        [Get("/invoices")]
        Task<InvoicesCollection> GetInvoicesAsync();

        [Get("/transactions")]
        Task<TransactionCollection> GetTransactionsAsync();

        [Get("/expenses")]
        Task<ExpenseCollection> GetExpensesAsync();

        [Get("/visits")]
        Task<VisitsCollections> GetVisitsAsync();
    }
}
