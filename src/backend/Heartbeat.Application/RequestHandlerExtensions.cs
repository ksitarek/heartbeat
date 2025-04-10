using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Heartbeat.Application;

public static class RequestHandlerExtensions
{

    public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
    {
        var assembly = typeof(EndpointsExtensions).Assembly;

        var requestHandlerInterfaceType = typeof(IRequestHandler);

        var serviceDescriptors = assembly.DefinedTypes
            .Where(t => t is { IsAbstract: false, IsInterface: false }
                        && t.IsAssignableFrom(requestHandlerInterfaceType))
            .Select(t => ServiceDescriptor.Transient(t, t));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }
}