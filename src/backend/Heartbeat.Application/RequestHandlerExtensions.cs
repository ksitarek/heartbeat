using Heartbeat.Application.Apps;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Heartbeat.Application;

public static class RequestHandlerExtensions
{

    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        return services.AddTransient<IndexRequestHandler>();
    }
}