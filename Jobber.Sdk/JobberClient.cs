using System.Threading.Tasks;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest;

namespace Jobber.Sdk
{
    public class JobberClient : IJobberClient
    {
        private IJobberApi _jobberApi;

        public JobberClient(IJobberApi jobberApi)
        {
            _jobberApi = jobberApi;
        }
        
        public Task CreateJobAsync(Job job)
        {
            throw new System.NotImplementedException();
        }

        public Task<JobCollection> GetJobsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task ModifyQuoteAsync(string quoteId, Quote quote)
        {
            throw new System.NotImplementedException();
        }

        public Task<QuotesCollection> GetQuotesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ClientCollection> GetClientsAsync(string searchQuery = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<InvoicesCollection> GetInvoicesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<TransactionCollection> GetTransactionsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ExpenseCollection> GetExpensesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<VisitsCollections> GetVisitsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}