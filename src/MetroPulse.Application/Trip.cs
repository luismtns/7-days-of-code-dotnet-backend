namespace MetroPulse.Application;

public sealed record Trip(string StationId, int PassengerCount, DateTimeOffset StartedAt);
