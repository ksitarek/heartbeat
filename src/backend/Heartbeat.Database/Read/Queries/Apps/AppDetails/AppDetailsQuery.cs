using Dapper;
using Heartbeat.Database.Read.Connection;

namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

internal class AppDetailsQuery : Query, IAppDetailsQuery
{
    public AppDetailsQuery(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public Task<AppDetails?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var query = SqlQueryCache.Get("AppDetails.sql");

        var cmd = new CommandDefinition(query, new { Id = id }, cancellationToken: cancellationToken);

        return Connection.QuerySingleOrDefaultAsync<AppDetails>(cmd);
    }
}