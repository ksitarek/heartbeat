namespace Heartbeat.Meta.DbMigrator.Providers;

internal interface IConnectionStringProvider
{
    string? GetConnectionString();
}