using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit;

namespace MetroPulse.Tests;

public sealed class FoundationTests
{
    [Fact]
    [Trait("Category", "Foundation")]
    public async Task LiveHealthEndpointResponds()
    {
        await using var app = new WebApplicationFactory<Program>();
        using var client = app.CreateClient();

        var response = await client.GetAsync("/health/live", CancellationToken.None);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
