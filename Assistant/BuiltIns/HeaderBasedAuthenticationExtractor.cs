using Assistant.Core;
using Microsoft.AspNetCore.Http;

namespace Assistant.BuiltIns
{
    public class HeaderBasedAuthenticationExtractor : IAuthenticationExtractor
    {
        public Authentication ExtractAuthenticationFrom(HttpRequest httpRequest)
        {
            return new Authentication
            {
                Type = 0,
                AuthenticationString = httpRequest.Headers["Authroization"]
            };
        }
    }
}