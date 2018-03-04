using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DialogFlow.Sdk.Models;
using Refit;

namespace DialogFlow.Sdk.Services
{
    public interface IDialogFlowService
    {
        [Post("/intents")]
        Task<IntentModificationResponse> CreateIntent([Body] Intent intent);

        [Put("/intents/{intentId}")]
        Task<IntentModificationResponse> UpdateIntent([AliasAs("intentId")] string intentId, [Body] Intent intent);
    }
}
