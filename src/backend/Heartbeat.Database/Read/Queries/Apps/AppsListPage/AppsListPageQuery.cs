using Dapper;
using Heartbeat.Database.Read.Connection;

namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

internal class AppsListPageQuery : Query, IAppsListPageQuery
{
    public AppsListPageQuery(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public async Task<ResultsPage<AppsListItem>> ExecuteAsync(string? search, int requestPageSize, long requestCurrentPage, CancellationToken cancellationToken)
    {
        var countSqlQuery = SqlQueryCache.Get("CountApps.sql");
        var pageSqlQuery = SqlQueryCache.Get("ListApps.sql");

        var countSqlCmd = new CommandDefinition(countSqlQuery, new
        {
            Search = search,
        }, cancellationToken: cancellationToken);

        var pageSqlCmd = new CommandDefinition(pageSqlQuery, new
        {
            Search = search,
            Limit = requestPageSize,
            Offset = (requestCurrentPage - 1) * requestPageSize
        }, cancellationToken: cancellationToken);

        return new ResultsPage<AppsListItem>(
            await Connection.QueryAsync<AppsListItem>(pageSqlCmd),
            await Connection.ExecuteScalarAsync<int>(countSqlCmd));
    }

}