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
    ValueTask<FirecrawlOpenApiClient> Get(CancellationToken cancellationToken = default);
}
