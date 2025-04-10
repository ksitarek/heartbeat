using System.Reflection.Metadata;
using Helpers;
using Nuke.Common;
using Nuke.Common.Tools.Docker;

partial class Build
{
    [Parameter] readonly string PostgresContainerName = "Heartbeat-Postgres";

    [Parameter] readonly string PostgresImage = "postgres:17";

    [Parameter] readonly string PostgresPassword = "yourStrong(!)Password";

    [Parameter] readonly int PostgresPort = 5432;

    [Parameter] readonly string PostgresUser = "postgres";

    Target RunPostgres => _ => _
        .Executes(async () =>
        {
            DockerHelpers.StopDockerContainer(PostgresContainerName);

            string[] environmentVariables =
            {
                $"POSTGRES_USER={PostgresUser}",
                $"POSTGRES_PASSWORD={PostgresPassword}"
            };

            DockerTasks.DockerRun(x => x
                                      .SetImage(PostgresImage)
                                      .SetName(PostgresContainerName)
                                      .SetPublish($"{PostgresPort}:5432")
                                      .SetDetach(true)
                                      .SetEnv(environmentVariables)
                                      .SetRm(true));

            var connectionString = PostgresHelpers.GetConnectionString(PostgresPort, PostgresUser, PostgresPassword);

            await PostgresHelpers.WaitForPostgresDb(PostgresContainerName, connectionString);
        })
        .Triggers(MigrateAllDatabases);    
}