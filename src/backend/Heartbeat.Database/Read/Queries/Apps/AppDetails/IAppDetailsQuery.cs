namespace Heartbeat.Database.Read.Queries.Apps.AppDetails;

public interface IAppDetailsQuery : IQuery
{
    Task<AppsListPage.AppDetails?> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}