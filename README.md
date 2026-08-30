[![](https://img.shields.io/nuget/v/soenneker.firecrawl.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.firecrawl.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Firecrawl.OpenApiClientUtil

Provides a scope-cached Kiota client over the long-lived authenticated Firecrawl HTTP client.

## Installation

```bash
dotnet add package Soenneker.Firecrawl.OpenApiClientUtil
```

## Registration

```csharp
using Soenneker.Firecrawl.OpenApiClientUtil.Registrars;

services.AddFirecrawlOpenApiClientUtilAsScoped();
```

The scoped utility intentionally depends on a singleton `IFirecrawlOpenApiHttpClient`. Disposing a utility scope releases its generated-client state while leaving the HTTP transport available to later scopes. A singleton utility registrar is also available when that is the desired application lifetime.

## Configuration

```json
{
  "Firecrawl": {
    "ApiKey": "your-firecrawl-key"
  }
}
```

The HTTP client package owns authentication and base-address configuration. `Firecrawl:ApiKey` is required; `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` are optional overrides. Keep the key in secret storage.

## Usage

```csharp
public sealed class PageScraper(IFirecrawlOpenApiClientUtil clientUtil)
{
    public async Task<ScrapeResponse?> Scrape(
        string url,
        CancellationToken cancellationToken)
    {
        FirecrawlOpenApiClient client = await clientUtil.Get(cancellationToken);
        return await client.Scrape.PostAsync(
            new ScrapePostRequestBody { Url = url },
            cancellationToken: cancellationToken);
    }
}
```

`Get()` creates at most one generated client per utility instance. The underlying `HttpClient` already contains the configured authentication header, so the Kiota adapter does not add a duplicate Authorization value.

The container owns injected utilities; do not dispose them manually. Applying URL allowlists, preventing private-network targets, controlling forwarded headers, and managing Firecrawl credit usage remain application responsibilities.
