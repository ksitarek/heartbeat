using Dapper;
using Heartbeat.Database.Read.Connection;

namespace Heartbeat.Database.Read.Queries.Apps.ListApps;

internal class ListAppsQuery : Query, IListAppsQuery
{
    public ListAppsQuery(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public async Task<List<AppsListItem>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var sqlQuery = SqlQueryCache.Get("ListApps.sql");

        var cmd = new CommandDefinition(sqlQuery, cancellationToken: cancellationToken);

        return (await Connection.QueryAsync<AppsListItem>(cmd)).ToList();
    }
}