using Heartbeat.Database.Read.Queries.Apps.AppsListPage;
using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application.Apps;

public record IndexRequest(string? Search, int PageSize, long CurrentPage);

public class IndexRequestHandler : IRequestHandler
{
    private readonly IAppsListPageQuery _appsListPageQuery;

    public IndexRequestHandler(IAppsListPageQuery appsListPageQuery)
    {
        _appsListPageQuery = appsListPageQuery;
    }

    public async Task<IResult> HandleAsync(IndexRequest request, CancellationToken cancellationToken)
    {
        var result = await _appsListPageQuery.ExecuteAsync(request.Search,
                                                           request.PageSize,
            request.CurrentPage,
            cancellationToken);

        return Results.Ok(result);
    }
}