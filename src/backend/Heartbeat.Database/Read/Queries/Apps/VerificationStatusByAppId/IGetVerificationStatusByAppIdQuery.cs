using Heartbeat.Domain.Verification;

namespace Heartbeat.Database.Read.Queries.Apps.VerificationStatusByAppId;

public interface IGetVerificationStatusByAppIdQuery : IQuery
{
    Task<VerificationStatus?> ExecuteAsync(Guid appId, CancellationToken cancellationToken);
}