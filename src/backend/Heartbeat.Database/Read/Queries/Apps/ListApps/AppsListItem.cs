using Heartbeat.Domain.Checks;
using Heartbeat.Domain.Verification;

namespace Heartbeat.Database.Read.Queries.Apps.ListApps;

public record AppsListItem(Guid AppId,
                           string AppLabel,

                           AvailabilityStatus LastCheckStatus,
                           DateTime LastCheckDateTime,

                           bool LastVerificationStatus,
                           DateTime LastVerificationDateTime);