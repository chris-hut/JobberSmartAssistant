using Microsoft.AspNetCore.Http;

namespace Assistant.Core
{
    public interface IAuthorizationExtractor
    {
        Authentication ExtractAuthenticationFrom(HttpRequest httpRequest);
    }
}