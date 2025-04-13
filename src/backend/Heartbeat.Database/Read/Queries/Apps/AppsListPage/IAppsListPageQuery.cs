namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public interface IAppsListPageQuery : IQuery
{
    Task<ResultsPage<AppsListItem>> ExecuteAsync(int requestPageSize, long requestCurrentPage, CancellationToken cancellationToken);
}