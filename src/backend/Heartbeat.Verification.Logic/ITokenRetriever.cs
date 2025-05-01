using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic;

public interface ITokenRetriever
{
    Task<VerificationToken> RetrieveToken(string baseUrl, VerificationStrategy verificationStrategy, CancellationToken cancellationToken);
}