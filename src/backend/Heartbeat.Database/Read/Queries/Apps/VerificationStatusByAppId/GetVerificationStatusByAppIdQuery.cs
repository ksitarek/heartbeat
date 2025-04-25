using Dapper;
using Heartbeat.Database.Read.Connection;
using Heartbeat.Domain.Verification;

namespace Heartbeat.Database.Read.Queries.Apps.VerificationStatusByAppId;

internal class GetVerificationStatusByAppIdQuery : Query, IGetVerificationStatusByAppIdQuery
{
    public GetVerificationStatusByAppIdQuery(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public Task<VerificationStatus?> ExecuteAsync(Guid appId, CancellationToken cancellationToken)
    {
        var sql = SqlQueryCache.Get("GetVerificationStatusByAppId.sql");

        var cmd = new CommandDefinition(sql, new
        {
            AppId = appId,
        }, cancellationToken: cancellationToken);

        return Connection.QuerySingleOrDefaultAsync<VerificationStatus>(cmd);
    }
}