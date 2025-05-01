namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public record AppDetails
{
    public required Guid Id { get; init; }
    public required string Label { get; init; }
}