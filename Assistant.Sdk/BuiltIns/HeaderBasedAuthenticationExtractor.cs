using Assistant.Sdk.Core;
using Microsoft.AspNetCore.Http;

namespace Assistant.Sdk.BuiltIns
{
    public class HeaderBasedAuthenticationExtractor : IAuthenticationExtractor
    {
        public Authentication ExtractAuthenticationFrom(HttpRequest httpRequest)
        {
            return new Authentication
            {
                Type = 0,
                AuthenticationString = "test"
            };
        }
    }
}