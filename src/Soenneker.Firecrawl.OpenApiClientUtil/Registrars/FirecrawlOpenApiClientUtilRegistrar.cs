using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Firecrawl.HttpClients.Registrars;
using Soenneker.Firecrawl.OpenApiClientUtil.Abstract;

namespace Soenneker.Firecrawl.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class FirecrawlOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="FirecrawlOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddFirecrawlOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddFirecrawlOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IFirecrawlOpenApiClientUtil, FirecrawlOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="FirecrawlOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddFirecrawlOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddFirecrawlOpenApiHttpClientAsSingleton()
                .TryAddScoped<IFirecrawlOpenApiClientUtil, FirecrawlOpenApiClientUtil>();

        return services;
    }
}
