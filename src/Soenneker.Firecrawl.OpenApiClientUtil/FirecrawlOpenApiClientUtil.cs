using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Firecrawl.HttpClients.Abstract;
using Soenneker.Firecrawl.OpenApiClientUtil.Abstract;
using Soenneker.Firecrawl.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Firecrawl.OpenApiClientUtil;

///<inheritdoc cref="IFirecrawlOpenApiClientUtil"/>
public sealed class FirecrawlOpenApiClientUtil : IFirecrawlOpenApiClientUtil
{
    private readonly AsyncSingleton<FirecrawlOpenApiClient> _client;

    public FirecrawlOpenApiClientUtil(IFirecrawlOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<FirecrawlOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Firecrawl:ApiKey");
            string authHeaderValueTemplate = configuration["Firecrawl:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new FirecrawlOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FirecrawlOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
