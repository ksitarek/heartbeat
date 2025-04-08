namespace Heartbeat.Domain.Checks;

public class CheckStatusLog
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required Guid WebAppCheckId { get; set; }

    public virtual Check WebAppCheck { get; set; } = null!;

    public required AvailabilityStatus Status { get; set; }

    public required DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public Guid? CheckResponseId { get; set; }

    public virtual CheckResponse? CheckResponse { get; set; }
}