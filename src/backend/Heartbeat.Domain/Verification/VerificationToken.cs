namespace Heartbeat.Domain.Verification;

public record VerificationToken
{
    public const string TokenPrefix = "$hb";
    public required string Version { get; init; }
    public required VerificationStrategy Strategy { get; init; }
    public required string Value { get; init; }

    private VerificationToken()
    {
    }

    public static VerificationToken Create(string version, VerificationStrategy verificationStrategy, string value)
    {
        return new() { Version = version, Strategy = verificationStrategy, Value = value };
    }

    public static VerificationToken FromString(string token)
    {
        var tokenParts = token.Split('.');

        if (tokenParts.Length != 4)
        {
            throw new ArgumentException("Invalid token format. Expected format: version.strategy.value");
        }


        if (!Enum.TryParse<VerificationStrategy>(tokenParts[2], out var strategy))
        {
            throw new ArgumentException($"Invalid strategy: {tokenParts[2]}");
        }

        return new VerificationToken() { Version = tokenParts[1], Strategy = strategy, Value = tokenParts[3] };
    }

    public override string ToString()
    {
        return $"{TokenPrefix}.{Version}.{Strategy}.{Value}";
    }
}