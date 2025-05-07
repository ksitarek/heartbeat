namespace Heartbeat.Domain.Verification;

public class VerificationConfiguration
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required Guid AppId { get; set; }

    public virtual App App { get; set; } = null!;

    public required VerificationToken VerificationToken { get; set; }

    public required VerificationStrategy VerificationStrategy { get; set; }

    public virtual ICollection<VerificationStatus> VerificationHistory { get; set; } = new List<VerificationStatus>();
}