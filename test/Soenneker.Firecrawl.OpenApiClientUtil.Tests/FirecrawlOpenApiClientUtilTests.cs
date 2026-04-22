using Soenneker.Firecrawl.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Firecrawl.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FirecrawlOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IFirecrawlOpenApiClientUtil _openapiclientutil;

    public FirecrawlOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IFirecrawlOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
