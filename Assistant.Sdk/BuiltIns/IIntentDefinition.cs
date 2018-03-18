using DialogFlow.Sdk.Models.Intents;

namespace Assistant.Sdk.BuiltIns
{
    public interface IIntentDefinition
    {
        Intent DefineIntent();
    }
}