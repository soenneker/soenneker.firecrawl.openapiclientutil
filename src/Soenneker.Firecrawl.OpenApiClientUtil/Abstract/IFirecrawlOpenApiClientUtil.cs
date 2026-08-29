using Soenneker.Firecrawl.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Firecrawl.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IFirecrawlOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured firecrawl Open API Client used by the firecrawl open api client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested firecrawl Open API Client.</returns>
    ValueTask<FirecrawlOpenApiClient> Get(CancellationToken cancellationToken = default);
}
