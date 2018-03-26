using DialogFlow.Sdk.Models.Intents;

namespace DialogFlow.Sdk.Builders
{
    public class ParameterBuilder
    {
        private readonly Parameter _parameter;

        private ParameterBuilder(string name, string dataType, string extension = "")
        {
            _parameter = new Parameter
            {
                Name = name,
                DataType = dataType,
                Value = $"${name}{extension}",
                Required = true
            };
        }

        public static ParameterBuilder Of(string name, string dataType, string extension = "")
        {
            return new ParameterBuilder(name, dataType, extension);
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