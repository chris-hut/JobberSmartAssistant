using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Jobber.Sdk.Extensions;
using Jobber.Sdk.Models.Clients;
using Jobber.Sdk.Models.Financials;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest;
using Jobber.Sdk.Rest.Requests;
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
        
        public async Task CreateJobAsync(CreateJobRequest createJobRequest)
        {
            GuardAgainstMissingFieldsIn(createJobRequest);
            
            try
            {
                var requestBody = JobberRequestUtils.CreateRequestBodyFor("job", createJobRequest);
                await _jobberApi.CreateJobAsync(requestBody);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed when creating job with description: {createJobRequest.Description}";
                throw ConvertToJobberException("Failed when creating", ex);
            }
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

        public async Task<VisitsCollections> GetTodaysVisitsAsync()
        {
            try
            {
                var today = DateTime.Today.ToUnixTime();
                var tomorrow = DateTime.Today.AddDays(1).ToUnixTime();
                return await _jobberApi.GetTodaysVisitsAsync(today, tomorrow);
            }
            catch (Exception ex)
            {
                var errorMessage = "Failed while getting todays visits.";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }
        
        public async Task<TransactionCollection> GetRangedTransactionsAsync(GetTransactionRequest getTransactionRequest)
        {
            long start = getTransactionRequest.Start.ToUnixTime();
            long end = getTransactionRequest.End.ToUnixTime();
            string timeUnit = getTransactionRequest.TimeUnit;
            //switch (timeUnit.TimeUnit.ToLower())
            //{
            //    case "month":
            //        end = DateTime.Today.AddDays(-(int)DateTime.Today.Day).ToUnixTime();
            //        start = DateTime.Today.AddDays(-(int)DateTime.Today.Day - (int)DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month-1) + 1).ToUnixTime();
            //        break;
            //    case "year":
            //        end = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfYear).ToUnixTime();
            //        start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfYear - (int)(DateTime.IsLeapYear(DateTime.Today.Year - 1) ? 365 : 364)).ToUnixTime();
            //        break;
            //    default:
            //        end = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 1).ToUnixTime();
            //        start = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 7).ToUnixTime();
            //        break;
            //}

            try
            {
                return await _jobberApi.GetRangedTransactionsAsync(start, end);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed while getting transactions for last {timeUnit} with start: {start} and end: {end}";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }

        public async Task<JobCollection> GetJobsAsync()
        {
            try
            {
                return await _jobberApi.GetJobsAsync();
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed while getting jobs";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }

        public async Task<JobCollection> GetRangedJobsAsync(string timeUnit)
        {
            long start = 0;
            long end = 0;
            switch (timeUnit.ToLower())
            {
                case "month":
                    var tillStartOfNextMonth = (int) DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) -
                                               (int) DateTime.Today.Day + 1;
                    var lengthOfNextMonth = (int) DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.AddDays(tillStartOfNextMonth).Month);
                    start = DateTime.Today.AddDays(tillStartOfNextMonth).ToUnixTime();
                    end = DateTime.Today.AddDays(tillStartOfNextMonth + lengthOfNextMonth).ToUnixTime();
                    break;
                default:
                    var tillStartOfNextWeek = 7 - (int) DateTime.Today.DayOfWeek + 1;
                    start = DateTime.Today.AddDays(tillStartOfNextWeek).ToUnixTime();
                    end = DateTime.Today.AddDays(7).ToUnixTime();
                    break;
            }

            try
            {
                return await _jobberApi.GetRangedJobsAsync(start, end);
            }
            catch (Exception ex)
            {
                var errorMessage = $"Failed while getting jobs for next {timeUnit} with start: {start} and end: {end}";
                throw ConvertToJobberException(errorMessage, ex);
            }
        }     
      
        public async Task<QuotesCollection> GetQuotesAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetQuotesAsync, "Failed while getting quotes");
        }

        public async Task<InvoicesCollection> GetInvoicesAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetInvoicesAsync, "Failed while getting invoices");
        }

        public async Task<TransactionCollection> GetTransactionsAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetTransactionsAsync, "Failed while getting transcations");
        }

        public async Task<VisitsCollections> GetVisitsAsync()
        {
            return await HandleErrorsIn(_jobberApi.GetVisitsAsync, "Failed while getting visits");
        }

        private static void GuardAgainstMissingFieldsIn(CreateJobRequest createJobRequest)
        {
            var errors = new List<string>();
            
            if (createJobRequest.ClientId == null) errors.Add("Client Id should be set");
            if (createJobRequest.JobType == null) errors.Add("JobType should be set. Use the JobTypes class to see the different types");
            if (createJobRequest.PropertyId == null) errors.Add("Property Id should be set");

            if (errors.Any())
            {
                var rawErrorList = JsonConvert.SerializeObject(errors, Formatting.Indented);
                var errorCause = $"Job is missing required parameters:\n{rawErrorList}";
                throw new JobberException("Failed to validate job", errorCause);
            }
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