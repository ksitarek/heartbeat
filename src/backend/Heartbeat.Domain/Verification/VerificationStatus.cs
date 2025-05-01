namespace Heartbeat.Domain.Verification;

public class VerificationStatus
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required Guid AppId { get; set; }

    public virtual App App { get; set; } = null!;

    public required DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public required string VerificationToken { get; set; }

    public required VerificationStrategy VerificationStrategy { get; set; }

    public required bool WasVerificationSuccessful { get; set; }

    public DateTimeOffset? LastVerificationDateTime { get; set; }
}