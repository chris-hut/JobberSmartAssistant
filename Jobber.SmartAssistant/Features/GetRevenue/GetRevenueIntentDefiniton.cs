using Assistant.Sdk.BuiltIns;
using DialogFlow.Sdk.Builders;
using DialogFlow.Sdk.Models.Intents;
using DialogFlow.Sdk.Models.Common;

namespace Jobber.SmartAssistant.Features.GetRevenue
{
    public class GetRevenueIntentDefiniton : IIntentDefinition
    {
        //FR-8.1: Getting the amount of revenue made within a unit of time
        //FR-8.2: Requesting the amount of revenue made specifying a time frame
        //FR-8.3: Requesting the amount of revenue made within a unit of time
        //FR-8.4: Requesting the amount of revenue made when given a bad time unit
        //FR-8.5: Requesting the amount of revenue made when given multiple bad time unit

        public Intent DefineIntent()
        {
            return IntentBuilder.For(Constants.Intents.GetRevenue)
                .TriggerOn("Get revenue")
                .TriggerOn("Get my revenue")
                .TriggerOn("How much revenue did we generate")
                .TriggerOn("How much money have we made")
                .TriggerOn("How much money did we make")
                .TriggerOn("How much were we paid")
                .TriggerOn("How much money we made")
                .TriggerOn("How much we made")
                .TriggerOn($"Get revenue from [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"Get revenue in [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much revenue did we generate [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much money have we made [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much money did we make [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much were we paid [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much money we made [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .TriggerOn($"How much we made [{Entity.DatePeriod}:{Constants.Variables.TimeUnit}:month]?")
                .WithOptionalParameter(ParameterBuilder.Of(Constants.Variables.TimeUnit, Entity.DatePeriod))
                .WithOptionalParameter(ParameterBuilder.Of(Constants.Variables.TimeUnitOriginal, Entity.DatePeriod, Constants.Variables.TimeUnit))
                .FulfillWithWebhook()
                .Build();
        }
    }
}
