namespace Heartbeat.Database.Read.Queries.Apps.AppsListPage;

public interface IAppDetailsQuery : IQuery
{
    Task<AppDetails> ExecuteAsync(Guid id, CancellationToken cancellationToken);
}