using Microsoft.AspNetCore.Http;

namespace Assistant.Core
{
    public interface IAuthenticationExtractor
    {
        Authentication ExtractAuthenticationFrom(HttpRequest httpRequest);
    }
}