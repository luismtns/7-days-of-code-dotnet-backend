var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/health/live", () => Results.Ok(new { status = "live" }));
app.MapGet("/", () => Results.Ok(new { project = "MetroPulse", guide = "docs/days/02-api.md" }));

app.Run();

public partial class Program;
