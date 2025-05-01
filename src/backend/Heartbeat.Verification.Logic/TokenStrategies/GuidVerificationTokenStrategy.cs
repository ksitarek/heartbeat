using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenStrategies;

internal class GuidVerificationTokenStrategy : IVerificationTokenStrategy
{
    public string Version
    {
        get => "V1";
    }

    public VerificationToken GenerateVerificationToken(VerificationStrategy verificationStrategy)
    {
        var guid = Guid.NewGuid();

        return VerificationToken.Create(Version, verificationStrategy, guid.ToString());
    }

    public bool IsValid(string tokenString, VerificationStrategy verificationStrategy)
    {
        try
        {
            if (!tokenString.StartsWith(VerificationToken.TokenPrefix))
            {
                return false;
            }

            var verificationToken = VerificationToken.FromString(tokenString);
            if (verificationToken.Version != Version)
            {
                return false;
            }

            if (verificationToken.Strategy != verificationStrategy)
            {
                return false;
            }

            if (!Guid.TryParse(verificationToken.Value, out Guid _))
            {
                return false;
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}