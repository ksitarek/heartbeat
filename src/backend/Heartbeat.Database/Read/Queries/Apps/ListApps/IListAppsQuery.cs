namespace Heartbeat.Database.Read.Queries.Apps.ListApps;

public interface IListAppsQuery : IQuery
{
    Task<List<object>> ExecuteAsync(CancellationToken cancellationToken);
}