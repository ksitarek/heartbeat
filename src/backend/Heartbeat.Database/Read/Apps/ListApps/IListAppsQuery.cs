namespace Heartbeat.Database.Read.Apps;

public interface IListAppsQuery : IQuery
{
    Task<List<object>> ExecuteAsync(CancellationToken cancellationToken);
}