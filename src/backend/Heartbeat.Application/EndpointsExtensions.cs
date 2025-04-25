using Heartbeat.Application.Apps;
using Heartbeat.Application.VerificationStatuses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Heartbeat.Application;

public static class EndpointsExtensions
{

    public static IApplicationBuilder UseEndpoints(this WebApplication app)
    {
        app.MapGet("/apps", ([FromServices] IndexRequestHandler handler,
                             [FromQuery] string? search,
                             [FromQuery] int pageSize,
                             [FromQuery] int currentPage,
                             CancellationToken cancellationToken)
            => handler.HandleAsync(new IndexRequest(search, pageSize, currentPage), cancellationToken));

        app.MapGet("/apps/{id}", ([FromServices] GetAppDetailsRequestHandler handler,
                                  [FromRoute] Guid id,
                                  CancellationToken cancellationToken)
                       => handler.HandleAsync(new GetAppDetailsRequest(id), cancellationToken));

        app.MapGet("/apps/{id}/verification-status", ([FromServices] GetVerificationStatusDetailsRequestHandler handler,
                                  [FromRoute] Guid id,
                                  CancellationToken cancellationToken)
                       => handler.HandleAsync(new GetVerificationStatusDetailsRequest(id), cancellationToken));

        return app;
    }
}