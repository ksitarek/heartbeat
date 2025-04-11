using Heartbeat.Database;
using Heartbeat.Database.Read.Apps;
using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application.Apps;

public class IndexRequestHandler : IRequestHandler
{
    private readonly IListAppsQuery _listAppsQuery;

    public IndexRequestHandler(IListAppsQuery listAppsQuery)
    {
        _listAppsQuery = listAppsQuery;
    }

    public async Task<IResult> HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _listAppsQuery.ExecuteAsync(cancellationToken);

        return Results.Ok(result);
    }
}