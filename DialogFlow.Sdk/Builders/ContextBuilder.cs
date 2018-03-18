using DialogFlow.Sdk.Models.Common;

namespace DialogFlow.Sdk.Builders
{
    public class ContextBuilder
    {
        private readonly Context _context;

        private ContextBuilder(string name)
        {
            _context = new Context
            {
                Name = name,
                Lifespan = 1
            };
        }

        public static ContextBuilder For(string name)
        {
            return new ContextBuilder(name);
        }

        public ContextBuilder Lifespan(int lifespan)
        {
            _context.Lifespan = lifespan;
            return this;
        }

        public ContextBuilder WithParameter(string key, string value)
        {
            _context.Parameters[key] = value;
            return this;
        }

        public Context Build()
        {
            return _context;
        }
    }
}