using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Sdk.Core;
using DialogFlow.Sdk;
using DialogFlow.Sdk.Intents;

namespace Assistant.Sdk.BuiltIns
{
    public class DialogFlowIntentSynchronizer : IIntentSynchronizer
    {
        private readonly IDialogFlowService _dialogFlowService;

        public DialogFlowIntentSynchronizer(IDialogFlowService dialogFlowService)
        {
            _dialogFlowService = dialogFlowService;
        }

        public async Task SynchronizeIntentsAsync(IEnumerable<Intent> intents)
        {
            await UpsertRegisteredIntentsAsync(intents);
            await DeleteUnregisteredIntentsAsync(intents);
        }

        private async Task UpsertRegisteredIntentsAsync(IEnumerable<Intent> intents)
        {
            var registeredIntents = await _dialogFlowService.GetIntentsAsync();
            var namesOfIntentsToSync = intents.Select(i => i.Name).ToHashSet();
            
            var nameKeyMap = new Dictionary<string, string>();
            registeredIntents.ToList().ForEach(i => nameKeyMap[i.Name] = i.Id);

            var createTasks = intents
                .Where(i => !nameKeyMap.ContainsKey(i.Name))
                .Select(i => _dialogFlowService.CreateIntentAsync(i));
            
            var updateTasks = intents
                .Where(i => nameKeyMap.ContainsKey(i.Name))
                .Select(i => _dialogFlowService.UpdateIntentAsync(nameKeyMap[i.Name], i));

            await Task.WhenAll(createTasks.Concat(updateTasks));
        }

        private async Task DeleteUnregisteredIntentsAsync(IEnumerable<Intent> intents)
        {
            var registeredIntents = await _dialogFlowService.GetIntentsAsync();
            var namesOfSyncedIntents = intents.Select(i => i.Name).ToHashSet();
            
            var nameKeyMap = new Dictionary<string, string>();
            registeredIntents.ToList().ForEach(i => nameKeyMap[i.Name] = i.Id);

            var deleteTasks = nameKeyMap
                .Where(entry => !namesOfSyncedIntents.Contains(entry.Key))
                .Select(entry => _dialogFlowService.DeleteIntentAsync(entry.Value));
                

            await Task.WhenAll(deleteTasks);
        }
    }
}