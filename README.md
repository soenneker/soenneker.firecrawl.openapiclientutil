[![](https://img.shields.io/nuget/v/soenneker.firecrawl.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.firecrawl.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.firecrawl.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.firecrawl.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.firecrawl.openapiclientutil/)

# Soenneker.Firecrawl.OpenApiClientUtil

Exposes a cached OpenAPI client instance.

## Install

```bash
dotnet add package Soenneker.Firecrawl.OpenApiClientUtil
```

## Quick start

```csharp
using Soenneker.Firecrawl.OpenApiClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddFirecrawlOpenApiClientUtilAsSingleton();
```

Adds `FirecrawlOpenApiClientUtil` as a singleton service.

## What you get

- `IFirecrawlOpenApiClientUtil` — Exposes a cached OpenAPI client instance.
- `FirecrawlOpenApiClientUtilRegistrar` — Registers the OpenAPI client utility for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `FirecrawlOpenApiClientUtilRegistrar.AddFirecrawlOpenApiClientUtilAsSingleton(services)` | Adds `FirecrawlOpenApiClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `FirecrawlOpenApiClientUtilRegistrar.AddFirecrawlOpenApiClientUtilAsScoped(services)` | Adds `FirecrawlOpenApiClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Dispose instances you own when their scope ends so held resources can be released.
