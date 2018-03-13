using DialogFlow.Sdk.Intents;

namespace DialogFlow.Sdk.Builders
{
    public class ParameterBuilder
    {
        private readonly Parameter _parameter;

        private ParameterBuilder(string name, string dataType)
        {
            _parameter = new Parameter
            {
                Name = name,
                DataType = dataType,
                Value = $"${name}",
                Required = true
            };
        }

        public static ParameterBuilder Of(string name, string dataType)
        {
            return new ParameterBuilder(name, dataType);
        }

        public ParameterBuilder WithPrompt(string prompt)
        {
            _parameter.Prompts.Add(prompt);
            return this;
        }

        public Parameter Build()
        {
            return _parameter;
        }
    }
}