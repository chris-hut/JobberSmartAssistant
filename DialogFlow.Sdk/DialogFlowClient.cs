using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DialogFlow.Sdk.Intents;
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
                throw ConverToDialogFlowException(ex, error);
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
                throw ConverToDialogFlowException(ex, error);
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
                throw ConverToDialogFlowException(ex, error);
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
                throw ConverToDialogFlowException(ex, error);
            }
        }

        private Exception ConverToDialogFlowException(ApiException ex, string errorMessage)
        {
            var content = ex.GetContentAs<IntentStatusResponse>();
            throw new DialogFlowException(errorMessage, content);
        }
    }
}