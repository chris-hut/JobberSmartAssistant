using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest;
using Refit;

namespace Jobber.Sdk
{
    public class JobberClient : IJobberClient
    {
        private readonly IJobberApi _jobberApi;

        public JobberClient(IJobberApi jobberApi)
        {
            _jobberApi = jobberApi;
        }
        
        public async Task CreateJobAsync(Job job)
        {
            try
            {
                var requestBody = JobberRequestUtils.CreateRequestBodyFor("job", job);
                await _jobberApi.CreateJobAsync(requestBody);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed when creating job with description: {job.Description}";
                throw ConvertToJobberException("Failed when creating", ex);
            }
        }

        public async Task<JobCollection> GetJobsAsync()
        {
            return await _jobberApi.GetJobsAsync();
        }

        public async Task UpdateQuoteAsync(string quoteId, Quote quote)
        {
            var requestBody = JobberRequestUtils.CreateRequestBodyFor("quote", quote);
            await _jobberApi.UpdateQuoteAsync(quoteId, requestBody);
        }

        public async Task<QuotesCollection> GetQuotesAsync()
        {
            return await _jobberApi.GetQuotesAsync();
        }

        public async Task<ClientCollection> GetClientsAsync(string searchQuery = "")
        {
            return await _jobberApi.GetClientsAsync(searchQuery);
        }

        public async Task<InvoicesCollection> GetInvoicesAsync()
        {
            return await _jobberApi.GetInvoicesAsync();
        }

        public async Task<TransactionCollection> GetTransactionsAsync()
        {
            return await _jobberApi.GetTransactionsAsync();
        }

        public async Task<ExpenseCollection> GetExpensesAsync()
        {
            return await _jobberApi.GetExpensesAsync();
        }

        public async Task<VisitsCollections> GetVisitsAsync()
        {
            return await _jobberApi.GetVisitsAsync();
        }

        private static JobberException ConvertToJobberException(string errorMessage, Exception ex)
        {
            switch (ex)
            {
                case ApiException apiException:
                    return new JobberException(errorMessage, apiException.Content);
                default:
                    return new JobberException(errorMessage, ex.Message);
            }
        }
    }
}