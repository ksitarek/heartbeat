using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenReadStrategies;

public interface ITokenRetrieveStrategy
{
    Task<VerificationToken> RetrieveToken(string baseUrl, CancellationToken cancellationToken);
}