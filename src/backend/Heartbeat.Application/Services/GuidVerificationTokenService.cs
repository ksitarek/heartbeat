using Heartbeat.Domain.Verification;

namespace Heartbeat.Application.Services;

public class GuidVerificationTokenService : IVerificationTokenService
{
    public string Version
    {
        get => "V1";
    }

    public string GenerateVerificationToken(VerificationStrategy verificationStrategy)
    {
        var guid = Guid.NewGuid();

        return $"{Version}.{(int)verificationStrategy}.{guid:N}".ToUpperInvariant();
    }

    public bool IsValid(string verificationToken, VerificationStrategy verificationStrategy)
    {
        var parts = verificationToken.Split('.');

        if (parts.Length != 3)
        {
            return false;
        }

        if (parts[0] != Version)
        {
            return false;
        }

        if (!Enum.TryParse(parts[1], out VerificationStrategy strategy))
        {
            return false;
        }

        if (strategy != verificationStrategy)
        {
            return false;
        }

        if (!Guid.TryParse(parts[2], out _))
        {
            return false;
        }

        return true;
    }
}