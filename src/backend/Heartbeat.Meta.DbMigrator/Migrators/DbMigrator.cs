using System.Reflection;
using DbUp;
using DbUp.Helpers;
using Heartbeat.Meta.DbMigrator.Providers;
using Microsoft.Extensions.Logging;

namespace Heartbeat.Meta.DbMigrator.Migrators;

internal class DbMigrator : IDatabaseMigrator
{
    private readonly ILogger<DbMigrator> _logger;
    private readonly IConnectionStringProvider _connectionStringProvider;

    public DbMigrator(
        ILogger<DbMigrator> logger,
        IConnectionStringProvider connectionStringProvider)
    {
        _logger = logger;
        _connectionStringProvider = connectionStringProvider;
    }

    public void Migrate()
    {
        _logger.LogInformation("Migrating database");

        var connectionString = _connectionStringProvider.GetConnectionString();

        EnsureDatabase.For.PostgresqlDatabase(connectionString);

        var result = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(Program).Assembly,
                                           opts => opts.Contains("MigrationFiles"))
            .LogToConsole()
            .Build()
            .PerformUpgrade();

        if (result.Successful)
        {
            _logger.LogInformation("Successfully migrated DB");
        }
        else
        {
            _logger.LogError("Failed to migrate DB: {error}", result.Error);
        }
    }

    public void LoadTestData()
    {
        var connectionString = _connectionStringProvider.GetConnectionString();

        var result = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(),
                                           opts => opts.Contains("TestData"))
            .JournalTo(new NullJournal())
            .LogToConsole()
            .Build()
            .PerformUpgrade();

        if (!result.Successful)
        {
            _logger.LogError("Failed to load sample data to database.");
        }
        else
        {
            _logger.LogInformation("Sample data loaded to database.");
        }
    }
}