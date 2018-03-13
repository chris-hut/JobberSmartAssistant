using Microsoft.AspNetCore.Http;

namespace Assistant.Sdk.Core
{
    public interface IAuthenticationExtractor
    {
        Authentication ExtractAuthenticationFrom(HttpRequest httpRequest);
    }
}