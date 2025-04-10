
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;

partial class Build : NukeBuild
{
    readonly AbsolutePath DbMigratorPath = RootDirectory / "src/backend/Heartbeat.Meta.DbMigrator";
    
    [Parameter("TestCompanyId")] readonly string TestCompanyId = "TestCompanyId";
    
    Target MigrateAllDatabases => _ => _
        .Executes(() =>
        {
            DotNetTasks.DotNetRun(_ => _
                                      .SetProjectFile(DbMigratorPath)
                                      .SetApplicationArguments("migrate-all-clients"));
            
            DotNetTasks.DotNetRun(_ => _
                                      .SetProjectFile(DbMigratorPath)
                                      .SetApplicationArguments("load-test-data", "--client-id", TestCompanyId));
            
            
        });
}