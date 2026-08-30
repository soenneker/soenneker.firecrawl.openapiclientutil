using Soenneker.Firecrawl.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Firecrawl.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a generated Firecrawl client cached for the lifetime of the utility.
/// </summary>
public interface IFirecrawlOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured generated Firecrawl client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the client cached by this utility instance.</returns>
    ValueTask<FirecrawlOpenApiClient> Get(CancellationToken cancellationToken = default);
}
