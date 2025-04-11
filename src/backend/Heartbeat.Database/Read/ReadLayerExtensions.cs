using Heartbeat.Database.Read.Apps;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Heartbeat.Database.Read;

public static class ReadLayerExtensions
{
    public static IServiceCollection AddReadLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = new PostgresConnectionString()
        {
            ConnectionString = configuration.GetValue<string>("Npgsql:ConnectionString")
                               ?? throw new Exception("Npgsql:ConnectionString string is not configured.")
        };

        return services.AddSingleton(connectionString)
            .AddTransient<SqlConnection>()
            .AddQueries();
    }

    private static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = typeof(ReadLayerExtensions).Assembly;

        var queryInterface = typeof(IQuery);

        var serviceDescriptors = assembly.DefinedTypes
            .Where(type => type is { IsAbstract: false, IsClass: true })
            .Where(type => type.IsAssignableTo(queryInterface))
            .Select(type => new ServiceDescriptor(
                        type.GetInterfaces().First(i => i.FullName!.StartsWith("Heartbeat") && i != queryInterface),
                        type,
                        ServiceLifetime.Transient));

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }
}