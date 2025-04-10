namespace Heartbeat.Meta.DbMigrator.Providers;

internal interface ICompaniesProvider
{
    IEnumerable<string> GetCompanies();
}