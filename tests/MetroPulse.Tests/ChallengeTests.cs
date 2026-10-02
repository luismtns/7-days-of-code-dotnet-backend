using System.Net;
using MetroPulse.Application;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using Xunit;

namespace MetroPulse.Tests;

public sealed class ChallengeTests
{
    [Fact]
    [Trait("Category", "Challenge")]
    [Trait("Day", "1")]
    public void TotalPassengersHandlesAnEmptySequenceAndSeveralTrips()
    {
        TripStatistics.TotalPassengers([]).ShouldBe(0);
        var trips = new[]
        {
            new Trip("ST-101", 3, DateTimeOffset.Parse("2026-01-01T10:00:00Z")),
            new Trip("ST-102", 4, DateTimeOffset.Parse("2026-01-01T11:00:00Z"))
        };

        TripStatistics.TotalPassengers(trips).ShouldBe(7);
    }

    [Fact]
    [Trait("Category", "Challenge")]
    [Trait("Day", "2")]
    public async Task StationsEndpointReturnsJson()
    {
        await using var app = new WebApplicationFactory<Program>();
        using var client = app.CreateClient();

        var response = await client.GetAsync("/api/v1/stations", CancellationToken.None);

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.Content.Headers.ContentType?.MediaType.ShouldBe("application/json");
    }
}
