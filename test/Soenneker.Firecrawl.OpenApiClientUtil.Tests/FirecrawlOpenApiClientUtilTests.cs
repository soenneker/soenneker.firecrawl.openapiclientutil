using Soenneker.Firecrawl.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Firecrawl.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class FirecrawlOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IFirecrawlOpenApiClientUtil _openapiclientutil;

    public FirecrawlOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IFirecrawlOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
