using Microsoft.Extensions.Configuration;

namespace Heartbeat.Meta.DbMigrator.Providers;

internal class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly IConfiguration _configuration;

    public ConnectionStringProvider(IConfiguration configuration) => _configuration = configuration;

    public string? GetConnectionString() =>
        _configuration["Npgsql:ConnectionString"];
}