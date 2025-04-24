using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application;

internal interface IRequestHandler<T>
{
    Task<IResult> HandleAsync(T request, CancellationToken cancellationToken);
}