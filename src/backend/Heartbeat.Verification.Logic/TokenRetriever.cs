using Heartbeat.Domain.Verification;
using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.Logic;

public class TokenRetriever : ITokenRetriever
{
    private readonly IServiceProvider _serviceProvider;

    public TokenRetriever(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<VerificationToken> RetrieveToken(string baseUrl,
                                                 VerificationStrategy verificationStrategy,
                                                 CancellationToken cancellationToken)
    {
        var retrieverStrategy = _serviceProvider.GetKeyedService<ITokenRetrieveStrategy>(
            TokenRetrieverExtensions.GetVerificationStrategyKey(verificationStrategy));

        if (retrieverStrategy == null)
        {
            throw new InvalidOperationException($"No verification strategy configured for key {verificationStrategy}.");
        }

        return retrieverStrategy.RetrieveToken(baseUrl, cancellationToken);
    }
}