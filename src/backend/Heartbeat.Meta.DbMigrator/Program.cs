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

app.AddCommand("migrate", (IDatabaseMigrator migrator) => migrator.Migrate());

app.AddCommand("load-test-data", (IDatabaseMigrator migrator) => migrator.LoadTestData());

await app.RunAsync();