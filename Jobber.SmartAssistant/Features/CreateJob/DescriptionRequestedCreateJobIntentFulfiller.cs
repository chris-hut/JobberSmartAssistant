using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Fulfillment;
using Jobber.Sdk;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Jobs;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using Newtonsoft.Json;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class DescriptionRequestedCreateJobIntentFulfiller : IJobberIntentFulfiller
    {
        public bool CanFulfill(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.IsForAction(Constants.Intents.DescritptionRequestedCreateJob);
        }

        public async Task<FulfillmentResponse> FulfillAsync(FulfillmentRequest fulfillmentRequest, IJobberClient jobberClient)
        {
            var jobDateTimeRange = GetDateTimeRangeForJobFrom(fulfillmentRequest);

            var job = new Job
            {
                //Client = fulfillmentRequest.GetContextParameterAsInt(Constants.Contexts.CreateJobClientSet, Constants.Variables.ClientId),
                StartAt = jobDateTimeRange.Start.ToUnixTime(),
                EndAt = jobDateTimeRange.End.ToUnixTime(),
                Description = fulfillmentRequest.GetParameter(Constants.Variables.JobDescription)
            };

            var req = JsonConvert.SerializeObject(job);
            await jobberClient.CreateJobAsync(job);

            return FulfillmentResponseBuilder.Create()
                .Speech("Okay I created the job for you!")
                .Build();
        }

        private static DateTimeRange GetDateTimeRangeForJobFrom(FulfillmentRequest fulfillmentRequest)
        {
            if (fulfillmentRequest.IsParameterDateRange(Constants.Variables.JobDate))
            {
                return fulfillmentRequest.GetParemterAsDateTimeRange(Constants.Variables.JobDate);
            }

            var dateSpecified = fulfillmentRequest.GetParameterAsDateTime(Constants.Variables.JobDate);

            return new DateTimeRange
            {
                Start = dateSpecified,
                End = dateSpecified.AddHours(3)
            };
        }
    }
}