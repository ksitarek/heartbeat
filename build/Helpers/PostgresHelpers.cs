using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Npgsql;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Docker;
using Serilog;

namespace Helpers;

public static class PostgresHelpers
{
    public static string GetConnectionString(int postgresPort, string postgresUser, string postgresPassword) =>
        $"Host=localhost:{postgresPort};Username={postgresUser};Password={postgresPassword};Database=postgres;TrustServerCertificate=True";

    public static async Task WaitForPostgresDb(string containerName,
                                               string connectionString)

    {
        var sw = new Stopwatch();
        sw.Start();

        var i = 0;
        while (true)
            try
            {
                await using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();
                await connection.CloseAsync();

                Log.Information("Postgres is running");

                return;
            }
            catch
            {
                Log.Information("Waiting for Postgres to start... {i}ms", i += 300);

                var r = DockerTasks.DockerPs(_ => new DockerPsSettings()
                                                 .SetFilter($"name={containerName}")
                                                 .SetQuiet(true)
                                                 .DisableProcessOutputLogging());

                if (r.Count == 0)
                {
                    Log.Fatal("Postgres container crashed.");
                    throw;
                }

                if (sw.Elapsed > TimeSpan.FromSeconds(10))
                    throw new TimeoutException("Postgres did not start in time.");

                await Task.Delay(TimeSpan.FromMilliseconds(300));
            }
    }
}