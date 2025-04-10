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

    public async Task<IResult> HandleAsync(CancellationToken cancellationToken)
    {
        return Results.Ok();
    }
}