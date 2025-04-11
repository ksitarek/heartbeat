using Heartbeat.Database;
using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application.Apps;

public class IndexRequestHandler : IRequestHandler
{
    private readonly HeartbeatDbContext _context;

    public IndexRequestHandler(HeartbeatDbContext context)
    {
        _context = context;
    }

    public Task<IResult> HandleAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Results.Ok());
    }
}