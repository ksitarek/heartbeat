namespace Heartbeat.Database.Read.Queries;

public record ResultsPage<T>(IEnumerable<T> Items, int TotalCount);