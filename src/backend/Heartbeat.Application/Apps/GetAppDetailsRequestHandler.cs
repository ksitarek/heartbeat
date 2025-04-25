using Heartbeat.Database.Read.Queries.Apps.AppDetails;
using Heartbeat.Database.Read.Queries.Apps.AppsListPage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Heartbeat.Application.Apps;

public record GetAppDetailsRequest(Guid Id);
public class GetAppDetailsRequestHandler : IRequestHandler<GetAppDetailsRequest>
{
    private readonly IAppDetailsQuery _appDetailsQuery;

    public GetAppDetailsRequestHandler(IAppDetailsQuery appDetailsQuery)
    {
        _appDetailsQuery = appDetailsQuery;
    }

    public async Task<IResult> HandleAsync(GetAppDetailsRequest request, CancellationToken cancellationToken)
    {
        var appDetails = await _appDetailsQuery.ExecuteAsync(request.Id, cancellationToken);

        if (appDetails is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(appDetails);
    }
}