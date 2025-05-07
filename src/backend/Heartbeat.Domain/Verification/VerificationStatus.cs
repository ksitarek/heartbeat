namespace Heartbeat.Domain.Verification;

public class VerificationStatus
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required Guid VerificationConfigurationId { get; set; }

    public virtual VerificationConfiguration VerificationConfiguration { get; set; } = null!;

    public required DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public required VerificationToken VerificationToken { get; set; }

    public required VerificationStrategy VerificationStrategy { get; set; }

    public required bool WasVerificationSuccessful { get; set; }

}