using Heartbeat.Domain.Verification;
using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.Logic.TokenReadStrategies;

public static class TokenRetrieverExtensions
{
    public static IServiceCollection AddTokenRetriever(this IServiceCollection services)
    {
        services.AddSingleton<ITokenRetriever, TokenRetriever>();

        services.AddSingleton<IKeyedStrategyProvider<ITokenRetrieveStrategy>, KeyedStrategyProvider<ITokenRetrieveStrategy>>();

        services.AddTokenRetrieveStrategy<DnsTokenRetriever>(VerificationStrategy.DnsRecord);

        return services;
    }

    private static IServiceCollection AddTokenRetrieveStrategy<TStrategy>(this IServiceCollection services,
                                                                          VerificationStrategy verificationStrategy) where TStrategy : class, ITokenRetrieveStrategy
    {
        var key = GetVerificationStrategyKey(verificationStrategy);
        return services.AddKeyedSingleton<ITokenRetrieveStrategy, TStrategy>(key);
    }

    internal static string GetVerificationStrategyKey(VerificationStrategy strategy)
    {
        return $"verification-strategy-{strategy}";
    }
}