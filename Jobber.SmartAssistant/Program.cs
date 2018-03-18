using System;
using System.Threading;
using System.Threading.Tasks;
using Assistant.Sdk.BuiltIns;
using Assistant.Sdk.Core;
using DialogFlow.Sdk;
using DialogFlow.Sdk.Rest;
using Jobber.SmartAssistant.Core;
using Jobber.SmartAssistant.Features.CreateJob;
using Jobber.SmartAssistant.Features.Fallback;
using Jobber.SmartAssistant.Features.FavoriteNumber;
using Jobber.SmartAssistant.Features.Welcome;
using Jobber.SmartAssistant.Features.UnassignedVisits;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Jobber.SmartAssistant
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var config = LoadConfiguration();
            
            var webHostBuilder = WebHost.CreateDefaultBuilder()
                .UseUrls($"http://0.0.0.0:{config.Port}");

            await Assistant.Sdk.Assistant.Builder()
                .UseWebHostBuilder(webHostBuilder)
                .UseIntentRegistry(BuildIntentRegistry())
                .UseIntentSynchronizer(BuildIntentSynchronizerFrom(config))
                .UseIntentFulfiller(BuildIntentFulfiller())
                .BuildAndRunAsync();
        }

        private static IIntentRegistry BuildIntentRegistry()
        {
            return new DefaultIntentRegistry()
                .WithIntentDefinition(new WelcomeIntentDefinition())
                .WithIntentDefinition(new FallbackIntentDefinition())
                .WithIntentDefinition(new StartCreateJobIntentDefinition())
                .WithIntentDefinition(new ClientRequestedCreateJobIntentDefinition())
                .WithIntentDefinition(new DescriptionRequestedCreateJobintentDefintion())
                .WithIntentDefinition(new FavoriteNumberIntentDefinition())
                .WithIntentDefinition(new UnassignedVisitsIntentDefinition());
        }

        private static IIntentFulfiller BuildIntentFulfiller()
        {
            return new JobberSmartAssistantIntentFulfiller()
                .WithJobberIntentFulfiller(new ClientRequestedCreateJobIntentFulfiller())
                .WithJobberIntentFulfiller(new DescriptionRequestedCreateJobIntentFulfiller())
                .WithJobberIntentFulfiller(new FavoriteNumberIntentFulfiller())
                .WithJobberIntentFulfiller(new UnassignedVisitsFulfiller());
        }

        private static IIntentSynchronizer BuildIntentSynchronizerFrom(Configuration config)
        {
            return new DialogFlowIntentSynchronizer(BuildDialogFlowClientFrom(config));
        }

        private static IDialogFlowClient BuildDialogFlowClientFrom(Configuration config)
        {
            var dialogFlowConfig = new DialogFlowConfig
            {
                ApiKey = config.DialogFlowApiKey
            };

            return new DialogFlowClientFactory().CreateDialogFlowClient(dialogFlowConfig);
        }

        private static Configuration LoadConfiguration()
        {
            return new Configuration
            {
                DialogFlowApiKey = Environment.GetEnvironmentVariable("JSA_DIALOG_FLOW_KEY"),
                Port = GetPortFromEnvironment()
            };
        }

        private static int GetPortFromEnvironment()
        {
            var portValue = Environment.GetEnvironmentVariable("PORT");
            if (String.IsNullOrEmpty(portValue))
            {
                return 5000;
            }

            return int.Parse(portValue);
        }
    }
}