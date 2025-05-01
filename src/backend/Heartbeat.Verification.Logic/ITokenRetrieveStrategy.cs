using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic;

internal interface ITokenRetrieveStrategy
{
    Task<VerificationToken> RetrieveToken(string baseUrl, CancellationToken cancellationToken);
}