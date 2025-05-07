using Heartbeat.Domain.Checks;
using Heartbeat.Domain.Verification;

namespace Heartbeat.Domain;

public class App
{
    public required Guid Id { get; set; } = Guid.NewGuid();

    public required string Label { get; set; }


    public required string BaseUrl { get; set; }


    public virtual VerificationConfiguration VerificationConfiguration { get; set; }


    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();
}