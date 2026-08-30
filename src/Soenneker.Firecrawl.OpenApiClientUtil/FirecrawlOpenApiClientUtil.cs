using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Firecrawl.HttpClients.Abstract;
using Soenneker.Firecrawl.OpenApiClientUtil.Abstract;
using Soenneker.Firecrawl.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Firecrawl.OpenApiClientUtil;

public sealed class FirecrawlOpenApiClientUtil : IFirecrawlOpenApiClientUtil
{
    private readonly AsyncSingleton<FirecrawlOpenApiClient> _client;

    public FirecrawlOpenApiClientUtil(IFirecrawlOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<FirecrawlOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new FirecrawlOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FirecrawlOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
