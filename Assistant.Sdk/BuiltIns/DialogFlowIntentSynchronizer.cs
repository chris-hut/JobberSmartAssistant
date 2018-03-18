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
        private readonly IDialogFlowClient _dialogFlowClient;

        public DialogFlowIntentSynchronizer(IDialogFlowClient dialogFlowClient)
        {
            _dialogFlowClient = dialogFlowClient;
        }

        public async Task SynchronizeIntentsAsync(IEnumerable<Intent> intents)
        {
            var registeredIntents = await _dialogFlowClient.GetIntentsAsync();
            var namesOfIntentsToSync = intents.Select(i => i.Name).ToHashSet();
            
            var nameKeyMap = new Dictionary<string, string>();
            registeredIntents.ToList().ForEach(i => nameKeyMap[i.Name] = i.Id);

            var deleteTasks = nameKeyMap
                .Where(entry => !namesOfIntentsToSync.Contains(entry.Key))
                .Select(entry => _dialogFlowClient.DeleteIntentAsync(entry.Value));

            await Task.WhenAll(deleteTasks);
            
            var createTasks = intents
                .Where(i => !nameKeyMap.ContainsKey(i.Name))
                .Select(i => _dialogFlowClient.CreateIntentAsync(i));
            
            var updateTasks = intents
                .Where(i => nameKeyMap.ContainsKey(i.Name))
                .Select(i => _dialogFlowClient.UpdateIntentAsync(nameKeyMap[i.Name], i));

            await Task.WhenAll(createTasks.Concat(updateTasks));
        }
    }
}