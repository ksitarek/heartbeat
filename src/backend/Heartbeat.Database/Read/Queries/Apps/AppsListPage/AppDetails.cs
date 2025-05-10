using Heartbeat.Domain.Verification;

namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public record AppDetails
{
    public required Guid Id { get; init; }
    public required string Label { get; init; }

    public required bool LastVerificationStatus { get; init; }
    public required DateTimeOffset? LastVerificationDate { get; init; }

    public required Guid? VerificationConfigurationId { get; init; }
    public required VerificationStrategy? VerificationStrategy { get; init; }
    public required string? VerificationToken { get; init; }
}