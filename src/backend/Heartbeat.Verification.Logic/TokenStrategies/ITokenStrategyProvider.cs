using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenStrategies;

public interface ITokenStrategyProvider
{
    VerificationToken GenerateVerificationToken(VerificationStrategy verificationStrategy);
    bool IsValid(string tokenString, VerificationStrategy verificationStrategy);
}