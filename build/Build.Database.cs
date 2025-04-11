using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;

partial class Build : NukeBuild
{
    readonly AbsolutePath DbMigratorPath = RootDirectory / "src/backend/Heartbeat.Meta.DbMigrator";

    [Parameter] readonly bool LoadTestData;

    Target MigrateDatabase => _ => _
        .Executes(() =>
        {
            DotNetTasks.DotNetRun(_ => _
                                      .SetProjectFile(DbMigratorPath)
                                      .SetApplicationArguments("migrate"));

            if (LoadTestData)
            {
                DotNetTasks.DotNetRun(_ => _
                                          .SetProjectFile(DbMigratorPath)
                                          .SetApplicationArguments("load-test-data"));
            }
        });
}