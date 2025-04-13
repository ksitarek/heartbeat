namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public interface IAppsListPageQuery : IQuery
{
    Task<ResultsPage<AppsListItem>> ExecuteAsync(CancellationToken cancellationToken);
}