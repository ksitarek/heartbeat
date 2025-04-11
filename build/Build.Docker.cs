using Helpers;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Docker;

partial class Build
{
    [Parameter] readonly AbsolutePath VolumesDirectory = RootDirectory / "volumes";
    
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

            string volume = $"{VolumesDirectory}/postgres:/var/lib/postgresql/data";

            DockerTasks.DockerRun(x => x
                                      .SetImage(PostgresImage)
                                      .SetName(PostgresContainerName)
                                      .SetPublish($"{PostgresPort}:5432")
                                      .SetDetach(true)
                                      .SetEnv(environmentVariables)
                                      .SetVolume(volume)
                                      .SetRm(true));

            var connectionString = PostgresHelpers.GetConnectionString(PostgresPort, PostgresUser, PostgresPassword);

            await PostgresHelpers.WaitForPostgresDb(PostgresContainerName, connectionString);
        })
        .Triggers(MigrateDatabase);
}