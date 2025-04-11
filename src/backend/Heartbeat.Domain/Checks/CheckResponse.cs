namespace Heartbeat.Domain.Checks;

public class CheckResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required bool ResponseCollected { get; set; }

    public required string? Response { get; set; }

    public required string Checksum { get; set; }
}