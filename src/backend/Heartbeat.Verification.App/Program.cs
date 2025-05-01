using Heartbeat.Domain.Verification;
using Heartbeat.Verification.Logic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

services.AddTokenRetriever();
services.AddTokenStrategy(configuration.GetSection("TokenStrategy"));

var serviceProvider = services.BuildServiceProvider();

var tokenRetriever = serviceProvider.GetRequiredService<ITokenRetriever>();

var token = await tokenRetriever.RetrieveToken("krystiansitarek.pl",
                                               VerificationStrategy.DnsRecord,
                                               CancellationToken.None);

Console.WriteLine(token);