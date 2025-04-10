using Cocona;
using Heartbeat.Meta.DbMigrator.Migrators;
using Heartbeat.Meta.DbMigrator.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();


builder.Configuration.AddConfiguration(
    new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build());

builder.Logging.AddSimpleConsole(o =>
{
    o.SingleLine = true;
    o.TimestampFormat = "yyyy-MM-dd HH:mm:ss zzz ";
});

builder.Services.AddSingleton<ICompaniesProvider, CompaniesProvider>();
builder.Services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
builder.Services.AddSingleton<IDatabaseMigrator, DbMigrator>();

var app = builder.Build();

app.AddCommand("migrate", (string clientId, IDatabaseMigrator migrator) => migrator.Migrate(clientId));

app.AddCommand("migrate-all-clients",
               (ICompaniesProvider companiesProvider, IDatabaseMigrator migrator) =>
               {
                   foreach (var companyId in companiesProvider.GetCompanies())
                   {
                       migrator.Migrate(companyId);
                   }
               });

app.AddCommand("load-test-data", (string clientId, IDatabaseMigrator migrator) => migrator.LoadTestData(clientId));

await app.RunAsync();