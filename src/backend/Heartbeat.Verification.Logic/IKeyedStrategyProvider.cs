namespace Heartbeat.Verification.Logic;

internal interface IKeyedStrategyProvider<out TStrategy> where TStrategy : notnull
{
    TStrategy? Get(string key);
    TStrategy GetRequired(string key);
}