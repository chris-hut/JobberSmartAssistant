using Jobber.Sdk.Models.Clients;

namespace Jobber.SmartAssistant.Features.CreateJob
{
    public class CreateJobContext
    {
        public Client Client { get; set; }
        public Property Property { get; set; }
    }
}