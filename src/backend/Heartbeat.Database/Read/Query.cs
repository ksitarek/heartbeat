using System.Reflection;
using Npgsql;

namespace Heartbeat.Database.Read;

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