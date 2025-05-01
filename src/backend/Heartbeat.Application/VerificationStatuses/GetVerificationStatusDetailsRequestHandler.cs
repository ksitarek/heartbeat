using Heartbeat.Database.Read.Queries.Apps.VerificationStatusByAppId;
using Microsoft.AspNetCore.Http;

namespace Heartbeat.Application.VerificationStatuses;

public class GetVerificationStatusDetailsRequestHandler : IRequestHandler<GetVerificationStatusDetailsRequest>
{
    private readonly IGetVerificationStatusByAppIdQuery _getVerificationStatusByAppIdQuery;

    public GetVerificationStatusDetailsRequestHandler(IGetVerificationStatusByAppIdQuery getVerificationStatusByAppIdQuery)
    {
        _getVerificationStatusByAppIdQuery = getVerificationStatusByAppIdQuery;
    }

    public async Task<IResult> HandleAsync(GetVerificationStatusDetailsRequest request, CancellationToken cancellationToken)
    {
        var verificationStatus = await _getVerificationStatusByAppIdQuery.ExecuteAsync(request.AppId, cancellationToken);

        if (verificationStatus is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(verificationStatus);
    }
}