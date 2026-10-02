var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var snapshots = new[]
{
    new StationSnapshot("ST-101", "Norte", 120),
    new StationSnapshot("ST-102", "Centro", 200),
    new StationSnapshot("ST-103", "Sul", 80),
    new StationSnapshot("ST-104", "Centro", 150)
};

app.MapGet("/health/live", () => Results.Ok(new { status = "live" }));
app.MapPost("/queries", (QueryRequest request) =>
{
    if (request.Name != "station-demand")
    {
        return Results.BadRequest(new { error = "Unknown query name" });
    }

    var rows = snapshots
        .Where(row => request.District is null || string.Equals(row.District, request.District, StringComparison.OrdinalIgnoreCase))
        .ToArray();

    return Results.Ok(new QueryResponse(rows));
});

app.Run();

public sealed record QueryRequest(string Name, string? District);
public sealed record StationSnapshot(string StationId, string District, int Trips);
public sealed record QueryResponse(IReadOnlyList<StationSnapshot> Rows);
