using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest.Requests;
using Refit;

namespace Jobber.Sdk
{
    public interface IJobberClient
    {
        Task CreateJobAsync(CreateJobRequest createJobRequest);
        Task<JobCollection> GetJobsAsync();
        Task UpdateQuoteAsync(string quoteId, Quote quote);
        Task<QuotesCollection> GetQuotesAsync();
        Task<ClientCollection> GetClientsAsync(string searchQuery = "");
        Task<InvoicesCollection> GetInvoicesAsync();
        Task<TransactionCollection> GetTransactionsAsync();
        Task<VisitsCollections> GetVisitsAsync();
        Task<VisitsCollections> GetTodayAssignedVisitsAsync(long user_id, long start=0);
        Task<VisitsCollections> GetTodaysVisitsAsync();
        Task<TransactionCollection> GetRangedTransactionsAsync(GetTransactionRequest getTransactionRequest);

    }
}
