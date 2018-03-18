using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest;
using Newtonsoft.Json;
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
            GuardAgainstMissingFieldsIn(job);
            
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

        private void GuardAgainstMissingFieldsIn(Job job)
        {
            var errors = new List<string>();
            
            if (job.Client == null) errors.Add("Client Id should be set");
            if (job.JobType == null) errors.Add("JobType should be set. Use the JobTypes class to see the different types");
            if (job.Property == null) errors.Add("Property Id should be set");

            if (errors.Any())
            {
                var rawErrorList = JsonConvert.SerializeObject(errors, Formatting.Indented);
                var errorCause = $"Job is missing required parameters:\n{rawErrorList}";
                throw new JobberException("Failed to validate job", errorCause);
            }
        }
        
        public async Task<JobCollection> GetJobsAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetJobsAsync, "Failed while getting jobs");
        }

        public async Task UpdateQuoteAsync(string quoteId, Quote quote)
        {
            try
            {
                var requestBody = JobberRequestUtils.CreateRequestBodyFor("quote", quote);
                await _jobberApi.UpdateQuoteAsync(quoteId, requestBody);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed when updating quote with id: {quoteId} and value: {quote.Cost}";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }

        public async Task<QuotesCollection> GetQuotesAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetQuotesAsync, "Failed while getting quotes");
        }

        public async Task<ClientCollection> GetClientsAsync(string searchQuery = "")
        {
            try
            {
                return await _jobberApi.GetClientsAsync(searchQuery);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed while getting clients with query: \"{searchQuery}\"";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }

        public async Task<InvoicesCollection> GetInvoicesAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetInvoicesAsync, "Failed while getting invoices");
        }

        public async Task<TransactionCollection> GetTransactionsAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetTransactionsAsync, "Failed while getting transcations");
        }

        public async Task<ExpenseCollection> GetExpensesAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetExpensesAsync, "Failed while getting expenses");
        }

        public async Task<VisitsCollections> GetVisitsAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetVisitsAsync, "Failed while getting visits");
        }

        private static async Task<T> HandleErrorsIn<T>(Func<Task<T>> function, string messageInCaseOfError)
        {
            try
            {
                return await function.Invoke();
            }
            catch (Exception ex)
            {
                throw ConvertToJobberException(messageInCaseOfError, ex);
            }
        }
        
        private static JobberException ConvertToJobberException(string errorMessage, Exception ex)
        {
            switch (ex)
            {
                case ApiException apiException:
                    var errorContent = apiException.GetContentAs<Dictionary<string, object>>();
                    var rawErrorContent = JsonConvert.SerializeObject(errorContent, Formatting.Indented);
                    return new JobberException(errorMessage, rawErrorContent);
                default:
                    return new JobberException(errorMessage, ex.Message);
            }
        }
    }
}