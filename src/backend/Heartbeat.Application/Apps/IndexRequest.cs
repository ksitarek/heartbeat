namespace Heartbeat.Application.Apps;

public record IndexRequest(string? Search, int PageSize, long CurrentPage);