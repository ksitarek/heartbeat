using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Serilog;

partial class Build
{
    [Parameter("Output directory - Default is 'out'")] public static readonly AbsolutePath OutputDirectory = RootDirectory / "out";

    [Parameter("DotNetVerbosity")] readonly DotNetVerbosity DotNetVerbosity = DotNetVerbosity.minimal;

    readonly AbsolutePath APIDll = OutputDirectory / "Heartbeat.API.dll";

    Target Clean => _ => _
        .Executes(() =>
        {
            OutputDirectory.DeleteDirectory();
            Log.Information("Deleted output directory: {OutputDirectory}", OutputDirectory);

            RootDirectory.GlobDirectories("**/bin", "**/obj")
                .ForEach(d =>
                {
                    d.DeleteDirectory();
                    Log.Information("Deleted directory: {Directory}", d);
                });
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore(t => t
                                          .SetProjectFile(Solution)
                                          .SetVerbosity(DotNetVerbosity));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(t => t
                                        .SetConfiguration(Configuration)
                                        .SetProjectFile(Solution)
                                        .SetNoRestore(true)
                                        .SetOutputDirectory(OutputDirectory)
                                        .SetVerbosity(DotNetVerbosity));
        });
}