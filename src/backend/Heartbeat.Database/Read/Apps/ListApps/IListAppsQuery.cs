namespace Heartbeat.Database.Read.Apps.ListApps;

public interface IListAppsQuery : IQuery
{
    Task<List<object>> ExecuteAsync(CancellationToken cancellationToken);
}