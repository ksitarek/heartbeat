using DbUp.Engine;

namespace Heartbeat.Meta.DbMigrator.Migrators;

internal interface IDatabaseMigrator
{
    void Migrate(string companyId);
    void LoadTestData(string companyId);
}