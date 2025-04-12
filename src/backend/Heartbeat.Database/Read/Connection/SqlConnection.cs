using Npgsql;

namespace Heartbeat.Database.Read.Connection;

internal class SqlConnection : IAsyncDisposable
{
    private NpgsqlConnection? _sqlConnection;
    private readonly string _connectionString;

    public SqlConnection(PostgresConnectionString connectionString)
    {
        _connectionString = connectionString.ConnectionString;
    }


    public NpgsqlConnection Connection
    {
        get
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new NpgsqlConnection(_connectionString);
                _sqlConnection.Open();
            }

            return _sqlConnection;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_sqlConnection != null)
        {
            await _sqlConnection.CloseAsync();
            _sqlConnection.Dispose();
        }
    }
}