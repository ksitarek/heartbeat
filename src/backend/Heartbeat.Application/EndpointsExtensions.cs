using Heartbeat.Application.Apps;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Heartbeat.Application;

public static class EndpointsExtensions
{

    public static IApplicationBuilder UseEndpoints(this WebApplication app)
    {
        app.MapGet("/apps", ([FromServices] IndexRequestHandler handler,
                             [FromQuery] string search,
                             [FromQuery] int pageSize,
                             [FromQuery] int currentPage,
                             CancellationToken cancellationToken)
            => handler.HandleAsync(new IndexRequest(search, pageSize, currentPage), cancellationToken));

        return app;
    }
}