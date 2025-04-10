using Heartbeat.Application.Apps;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Heartbeat.Application;

public static class EndpointsExtensions
{

    public static IApplicationBuilder UseEndpoints(this WebApplication app)
    {
        app.MapGet("/apps", ([FromServices] IndexRequestHandler handler, CancellationToken cancellationToken)
            => handler.HandleAsync(cancellationToken));

        return app;
    }
}