using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.Logic.TokenStrategies;

public static class TokenStrategyExtensions
{
    public static IServiceCollection AddTokenStrategy(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenStrategyConfiguration = new TokenStrategyConfiguration();

        configuration.Bind(tokenStrategyConfiguration);

        services.AddSingleton(tokenStrategyConfiguration);

        services.AddSingleton<ITokenStrategyProvider, TokenStrategyProvider>();

        services.AddSingleton<IKeyedStrategyProvider<IVerificationTokenStrategy>, KeyedStrategyProvider<IVerificationTokenStrategy>>();

        services.AddVerificationTokenStrategy<GuidVerificationTokenStrategy>("V1");

        return services;
    }

    private static IServiceCollection AddVerificationTokenStrategy<TStrategy>(this IServiceCollection services,
        string version) where TStrategy : class, IVerificationTokenStrategy
    {
        var key = GetVerificationTokenStrategyKey(version);
        return services.AddKeyedTransient<IVerificationTokenStrategy, TStrategy>(key);
    }

    internal static string GetVerificationTokenStrategyKey(string version)
    {
        return $"verification-token-strategy-{version}";
    }
}