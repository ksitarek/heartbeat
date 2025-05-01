using Heartbeat.Domain.Verification;

namespace Heartbeat.Application.Services;

public interface IVerificationTokenService
{
    public string Version { get; }
    public string GenerateVerificationToken(VerificationStrategy verificationStrategy);

    public bool IsValid(string verificationToken, VerificationStrategy verificationStrategy);
}