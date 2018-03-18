using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Models.Intents;
using DialogFlow.Sdk.Rest;
using Refit;

namespace DialogFlow.Sdk
{
    public class DialogFlowClient : IDialogFlowClient
    {
        private readonly IDialogFlowApi _dialogFlowApi;

        public DialogFlowClient(IDialogFlowApi dialogFlowApi)
        {
            _dialogFlowApi = dialogFlowApi;
        }

        public async Task<IEnumerable<Intent>> GetIntentsAsync()
        {
            try
            {
                return await _dialogFlowApi.GetIntentsAsync();
            }
            catch (ApiException ex)
            {
                var error = $"Failed to get intents";
                throw ConvertToDialogFlowException(ex, error);
            }
        }

        public async Task CreateIntentAsync(Intent intent)
        {
            try
            {
                await _dialogFlowApi.CreateIntentAsync(intent);
            }
            catch (ApiException ex)
            {
                var error = $"Failed to create intent with name: {intent.Name}";
                throw ConvertToDialogFlowException(ex, error);
            }
        }

        public async Task UpdateIntentAsync(string intentId, Intent intent)
        {
            try
            {
                await _dialogFlowApi.UpdateIntentAsync(intentId, intent);
            }
            catch (ApiException ex)
            {
                var error = $"Failed to update intent with name: {intent.Name} and id: {intent.Id}";
                throw ConvertToDialogFlowException(ex, error);
            }
        }

        public async Task DeleteIntentAsync(string intentId)
        {
            try
            {
                await _dialogFlowApi.DeleteIntentAsync(intentId);
            }
            catch (ApiException ex)
            {
                var error = $"Failed to delete intent with id: {intentId}";
                throw ConvertToDialogFlowException(ex, error);
            }
        }

        private Exception ConvertToDialogFlowException(ApiException ex, string errorMessage)
        {
            var content = ex.GetContentAs<DialogFlowStatusResponse>();
            return new DialogFlowException(errorMessage, content);
        }
    }
}