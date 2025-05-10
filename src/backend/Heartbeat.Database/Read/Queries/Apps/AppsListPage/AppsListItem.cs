using Heartbeat.Domain.Checks;

namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public record AppsListItem(Guid AppId,
                           string AppLabel,

                           bool LastVerificationStatus,
                           DateTime LastVerificationDateTime);