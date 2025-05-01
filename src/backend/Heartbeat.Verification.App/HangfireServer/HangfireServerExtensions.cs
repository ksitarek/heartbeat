using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.App.HangfireServer;

public static class HangfireServerExtensions
{
    public static IServiceCollection AddHangfireServer(this IServiceCollection services, IConfiguration configuration)
    {
        var options = new BackgroundJobServerOptions();

        configuration.Bind(options);

        services.AddSingleton(options);

        services.AddSingleton((sp) => new BackgroundJobServer(sp.GetRequiredService<BackgroundJobServerOptions>()));

        return services;
    }

}