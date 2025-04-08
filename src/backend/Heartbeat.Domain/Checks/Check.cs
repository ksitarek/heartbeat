namespace Heartbeat.Domain.Checks;

public class Check
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required Guid WebAppId { get; set; }

    public virtual WebApp WebApp { get; set; } = null!;

    public required string Label { get; set; }

    public required TimeSpan Interval { get; set; }

    public required TimeSpan Timeout { get; set; }

    public required string Url { get; set; }

    public required int Port { get; set; }

    public required string? ExpectedResponse { get; set; }

    public required bool CollectResponse { get; set; }

    public virtual ICollection<CheckStatusLog> CheckStatusLogs { get; set; } = new List<CheckStatusLog>();
}