using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenStrategies;

internal class TokenStrategyProvider : ITokenStrategyProvider
{
    private IVerificationTokenStrategy? _tokenStrategy;
    private readonly TokenStrategyConfiguration _configuration;
    private readonly IKeyedStrategyProvider<IVerificationTokenStrategy> _strategyProvider;

    private IVerificationTokenStrategy? TokenStrategy
    {
        get
        {
            if (_tokenStrategy == null)
            {
                var key = TokenStrategyExtensions.GetVerificationTokenStrategyKey(_configuration.Version);
                _tokenStrategy = _strategyProvider.Get(key);
            }

            return _tokenStrategy;
        }
    }

    public TokenStrategyProvider(TokenStrategyConfiguration configuration, IKeyedStrategyProvider<IVerificationTokenStrategy> strategyProvider)
    {
        _configuration = configuration;
        _strategyProvider = strategyProvider;
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