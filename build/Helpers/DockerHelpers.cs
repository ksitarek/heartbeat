using Nuke.Common.Tools.Docker;
using Serilog;

namespace Helpers;

public static class DockerHelpers
{
    public static void StopDockerContainer(string containerName)
    {
        Log.Information("Stopping and removing existing container");

        DockerTasks.DockerRm(x => x
                                 .SetContainers(containerName)
                                 .SetForce(true));
    }
}