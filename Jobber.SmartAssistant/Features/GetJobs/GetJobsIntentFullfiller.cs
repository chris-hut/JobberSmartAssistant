using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Microsoft.EntityFrameworkCore.Storage;


namespace Jobber.SmartAssistant.Features.GetJobs
{
    public class GetJobsIntentFullfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.GetJobs);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest,
            IJobberClient jobberClient)
        {
            var jobs = await jobberClient.GetJobsAsync();
            
            switch (jobs.Count)
            {
                case 0:
                    return BuildNoJobResponse();
                case 1:
                    return BuildJobFoundResponse(jobs.Jobs.First());
                default:
                    return buildMultipleJobsFoundResponse(jobs);
            }
        }

        private static FulfillmentResponse BuildNoJobResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You don't have any assigned visits today.")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse BuildJobFoundResponse(Job job) 
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have one job today. Here's the description: {job.Description}")
                .MarkEndOfAssistantConversation()
                .Build();
        }

        private static FulfillmentResponse buildMultipleJobsFoundResponse(JobCollection jobs)
        {
            // This is temporary, need to specify date range
            var first5_job = jobs.Jobs.Take(5);
            StringBuilder sb = new StringBuilder();
            foreach (Job job in first5_job)
            {
                sb.Append(job.Description + ". ");
            }
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have {jobs.Count} jobs today. Jobs include: {sb.ToString()}")
                .MarkEndOfAssistantConversation()
                .Build();
        }
    }
}