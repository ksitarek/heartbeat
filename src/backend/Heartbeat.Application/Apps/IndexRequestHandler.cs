using Heartbeat.Database.Read.Queries.Apps.AppsListPage;
using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application.Apps;

public class IndexRequestHandler : IRequestHandler
{
    private readonly IAppsListPageQuery _appsListPageQuery;

    public IndexRequestHandler(IAppsListPageQuery appsListPageQuery)
    {
        _appsListPageQuery = appsListPageQuery;
    }

    public async Task<IResult> HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _appsListPageQuery.ExecuteAsync(cancellationToken);

        return Results.Ok(result);
    }
}