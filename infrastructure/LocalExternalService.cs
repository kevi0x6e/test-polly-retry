using System.Diagnostics.CodeAnalysis;
using domain.Infrastructure;

namespace infrastructure;

[ExcludeFromCodeCoverage]
public class LocalExternalService : ILocalExternalService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LocalExternalService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<bool> GetStatusCodeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient("LocalPollyRetryTest");

        var response = await client.GetAsync("https://httpbin.org/get");
        return response.IsSuccessStatusCode;
    }
}
