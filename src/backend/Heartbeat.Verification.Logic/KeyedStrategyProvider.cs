using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.Logic;

internal class KeyedStrategyProvider<TStrategy> : IKeyedStrategyProvider<TStrategy> where TStrategy : notnull
{
    private readonly IServiceProvider _serviceProvider;

    public KeyedStrategyProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TStrategy? Get(string key)
    {
        return _serviceProvider.GetKeyedService<TStrategy>(key);
    }

    public TStrategy GetRequired(string key)
    {
        return _serviceProvider.GetRequiredKeyedService<TStrategy>(key);
    }
}