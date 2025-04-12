namespace Heartbeat.Database.Read.Queries.Apps.ListApps;

public interface IListAppsQuery : IQuery
{
    Task<List<AppsListItem>> ExecuteAsync(CancellationToken cancellationToken);
}