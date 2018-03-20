using System.Linq;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;


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
            
            return FulfillmentResponseBuilder.Create()
                .Speech($"Your jobs today are laundry and mowing.")
                .Build();
            
            /*
            switch (jobs.Count)
            {
                case 0:
                    return BuildNoJobResponse();
                case 1:
                    return BuildJobFoundResponse(jobs.Jobs.First());
                default:
                    return buildMultipleJobsFoundResponse(jobs);
            }
            */
        }

        private static FulfillmentResponse BuildNoJobResponse()
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You don't have any assigned jobs today.")
                .Build();
        }

        private static FulfillmentResponse BuildJobFoundResponse(Job job) 
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have one job today. Here's the description: Tada")
                .Build();
        }

        private static FulfillmentResponse buildMultipleJobsFoundResponse(JobCollection jobs)
        {
            return FulfillmentResponseBuilder.Create()
                .Speech($"You have tada jobs today.")
                .Build();
        }
    }
}