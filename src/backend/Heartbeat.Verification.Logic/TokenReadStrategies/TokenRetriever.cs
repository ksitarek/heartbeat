using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenReadStrategies;

internal class TokenRetriever : ITokenRetriever
{
    private readonly IKeyedStrategyProvider<ITokenRetrieveStrategy> _strategyProvider;

    public TokenRetriever(IKeyedStrategyProvider<ITokenRetrieveStrategy> strategyProvider)
    {
        _strategyProvider = strategyProvider;
    }

    public Task<VerificationToken> RetrieveToken(string baseUrl,
                                                 VerificationStrategy verificationStrategy,
                                                 CancellationToken cancellationToken)
    {
        var retrieverStrategy = _strategyProvider.Get(
            TokenRetrieverExtensions.GetVerificationStrategyKey(verificationStrategy));

        if (retrieverStrategy == null)
        {
            throw new InvalidOperationException($"No verification strategy configured for key {verificationStrategy}.");
        }

        return retrieverStrategy.RetrieveToken(baseUrl, cancellationToken);
    }
}