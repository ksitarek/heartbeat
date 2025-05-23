using Dapper;
using Heartbeat.Database.Read.Connection;
using Npgsql;

namespace Heartbeat.Database.Read.Queries.Apps;

internal abstract class Query : IAsyncDisposable
{
    private readonly SqlConnection _sqlConnection;

    protected NpgsqlConnection Connection => _sqlConnection.Connection;

    protected Query(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public async ValueTask DisposeAsync() => await _sqlConnection.DisposeAsync();
}