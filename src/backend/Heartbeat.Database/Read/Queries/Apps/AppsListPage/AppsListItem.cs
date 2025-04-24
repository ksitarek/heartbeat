using Heartbeat.Domain.Checks;

namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public record AppsListItem(Guid AppId,
                           string AppLabel,

                           AvailabilityStatus LastCheckStatus,
                           DateTime LastCheckDateTime,

                           bool LastVerificationStatus,
                           DateTime LastVerificationDateTime);

public record AppDetails
{
    public required Guid Id { get; init; }
    public required string Label { get; init; }
}