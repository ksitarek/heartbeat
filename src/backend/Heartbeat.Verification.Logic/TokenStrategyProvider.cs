using Heartbeat.Domain.Verification;
using Heartbeat.Verification.Logic.TokenStrategies;
using Microsoft.Extensions.DependencyInjection;

namespace Heartbeat.Verification.Logic;

public class TokenStrategyProvider : ITokenStrategyProvider
{
    private readonly IServiceProvider _serviceProvider;
    private IVerificationTokenStrategy? _tokenStrategy;
    private readonly TokenStrategyConfiguration _configuration;

    private IVerificationTokenStrategy? TokenStrategy
    {
        get
        {
            if (_tokenStrategy == null)
            {
                var key = TokenStrategyExtensions.GetVerificationTokenStrategyKey(_configuration.Version);
                _tokenStrategy = _serviceProvider.GetKeyedService<IVerificationTokenStrategy>(key);
            }

            return _tokenStrategy;
        }
    }

    public TokenStrategyProvider(TokenStrategyConfiguration configuration, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public VerificationToken GenerateVerificationToken(VerificationStrategy verificationStrategy)
    {
        return TokenStrategy?.GenerateVerificationToken(verificationStrategy) ?? throw new InvalidOperationException("VerificationTokenStrategy not set.");
    }

    public bool IsValid(string tokenString, VerificationStrategy verificationStrategy)
    {
        return TokenStrategy?.IsValid(tokenString, verificationStrategy) ?? throw new InvalidOperationException("VerificationTokenStrategy not set.");
    }
}