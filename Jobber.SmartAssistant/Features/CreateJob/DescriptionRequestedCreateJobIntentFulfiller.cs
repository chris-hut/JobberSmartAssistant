using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Common;
using DialogFlow.Sdk.Models.Fulfillment;
using DialogFlow.Sdk.Models.Messages;
using Jobber.Sdk;
using Jobber.Sdk.Models;
using Jobber.Sdk.Models.Jobs;
using Jobber.Sdk.Rest.Requests;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Extensions;
using Jobber.SmartAssistant.GoogleMaps;
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
            var createJobDescription = fulfillmentRequest.GetParameter(Constants.Variables.JobDescription);
            var createJobContext = fulfillmentRequest.GetContextParameterAs<CreateJobContext>
                (Constants.Contexts.CreateJobClientSet, Constants.Variables.CreateJobContext);
            
            var createJobRequest = new CreateJobRequest
            {
                ClientId = createJobContext.Client.Id,
                PropertyId = createJobContext.Property.Id,
                StartAt = jobDateTimeRange.Start.ToUnixTime(),
                EndAt = jobDateTimeRange.End.ToUnixTime(),
                Description = createJobDescription
            };

            await jobberClient.CreateJobAsync(createJobRequest);

            return FulfillmentResponseBuilder.Create()
                .Speech(BuildResponseFrom(fulfillmentRequest))
                .WithMessage(BuildGoogleCardFrom(createJobContext, createJobDescription))
                .Build();
        }

        private static string BuildResponseFrom(FulfillmentRequest fulfillmentRequest)
        {
            return fulfillmentRequest.DoesRequestingDeviceHaveAScreen() ?
                "Okay I created the job. See the details below." :
                "Okay I created the job. I sent some details about it to your phone.";
        }
        
        private static GoogleCardMessage BuildGoogleCardFrom(CreateJobContext createJobContext, string description)
        {
            var mapImage = GoogleMapsHelper.GetStaticMapLinkFor(createJobContext.Property.MapAddress);
            var mapLink = GoogleMapsHelper.GetGoogleMapsLinkFor(createJobContext.Property.MapAddress);
            
            return GoogleCardBuilder.Create()
                .Title($"New Job for {createJobContext.Client.Name}")
                .Content(description)
                .Image(mapImage)
                .WithButton("Open Map", mapLink)
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