using DnsClient;
using Heartbeat.Domain.Verification;

namespace Heartbeat.Verification.Logic.TokenReadStrategies;

internal class DnsTokenRetriever : ITokenRetrieveStrategy
{
    private readonly LookupClient _client = new();

    public async Task<VerificationToken> RetrieveToken(string baseUrl, CancellationToken cancellationToken)
    {
        var queryResponse = await _client.QueryAsync(baseUrl, QueryType.TXT, cancellationToken: cancellationToken);

        var tokenString = queryResponse.Answers
            .TxtRecords()
            .SelectMany(x => x.Text)
            .FirstOrDefault(x => x.StartsWith(VerificationToken.TokenPrefix));

        if (tokenString is null)
        {
            throw new InvalidOperationException($"No verification token could be retrieved from DNS lookup.");
        }

        return VerificationToken.FromString(tokenString);
    }
}