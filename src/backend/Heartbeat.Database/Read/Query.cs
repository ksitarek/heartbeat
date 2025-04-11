using System.Reflection;
using Npgsql;

namespace Heartbeat.Database.Read;

internal abstract class Query : IAsyncDisposable
{
    private readonly SqlConnection _sqlConnection;
    private readonly Assembly _assembly;

    protected NpgsqlConnection Connection => _sqlConnection.Connection;

    protected Query(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
        _assembly = typeof(Query).Assembly;
    }

    protected string GetQuery(string name)
    {
        // todo consider loading to cache during startup
        var resourceName = _assembly.GetManifestResourceNames()
            .Single(str => str.EndsWith(name));

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new Exception($"Resource {resourceName} not found.");
        using var reader = new StreamReader(stream);
        var query = reader.ReadToEnd();

        return query;
    }

    public async ValueTask DisposeAsync() => await _sqlConnection.DisposeAsync();
}