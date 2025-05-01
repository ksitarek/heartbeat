using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenStrategies;

public interface IVerificationTokenStrategy
{
    public VerificationToken GenerateVerificationToken(VerificationStrategy verificationStrategy);

    public bool IsValid(string tokenString, VerificationStrategy verificationStrategy);
}