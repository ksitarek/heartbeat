using System.Collections.ObjectModel;
using System.Reflection;

namespace Heartbeat.Database.Read.Queries;

internal static class SqlQueryCache
{
    private static Assembly _assembly = typeof(SqlQueryCache).Assembly;

    private static ReadOnlyDictionary<string, string>? _queries;

    public static void Load()
    {
        var assembly = typeof(SqlQueryCache).Assembly;

        var resourceNames = assembly.GetManifestResourceNames()
            .Where(r => r.EndsWith(".sql"))
            .ToDictionary(x => string.Join('.', x.Split('.').TakeLast(2)), ReadResource);

        _queries = new ReadOnlyDictionary<string, string>(resourceNames);
    }

    public static string Get(string name)
    {
        if (_queries == null)
        {
            Load();
        }

        if (_queries!.TryGetValue(name, out var query))
        {
            return query;
        }

        throw new Exception($"Query {name} not found.");
    }

    private static string ReadResource(string resourceName)
    {
        using var stream = _assembly.GetManifestResourceStream(resourceName)
                           ?? throw new Exception($"Resource {resourceName} not found.");
        using var reader = new StreamReader(stream);
        var query = reader.ReadToEnd();

        return query;
    }
}