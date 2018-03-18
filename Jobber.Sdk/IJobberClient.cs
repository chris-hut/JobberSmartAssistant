using System.Threading.Tasks;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Refit;

namespace Jobber.Sdk
{
    public interface IJobberClient
    {
        Task CreateJobAsync([Body] Job job);
        Task<JobCollection> GetJobsAsync();
        Task UpdateQuoteAsync(string quoteId, Quote quote);
        Task<QuotesCollection> GetQuotesAsync();
        Task<ClientCollection> GetClientsAsync(string searchQuery = "");
        Task<InvoicesCollection> GetInvoicesAsync();
        Task<TransactionCollection> GetTransactionsAsync();
        Task<VisitsCollections> GetVisitsAsync();
    }
}
