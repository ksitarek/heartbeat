using Hangfire;
using Heartbeat.Domain.Verification;
using Heartbeat.Verification.App.HangfireServer;
using Heartbeat.Verification.Logic;
using Heartbeat.Verification.Logic.TokenReadStrategies;
using Heartbeat.Verification.Logic.TokenStrategies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

services.AddTokenRetriever();
services.AddTokenStrategy(configuration.GetSection("TokenStrategy"));
services.AddHangfireServer(configuration.GetSection("BackgroundJobServerOptions"));

var serviceProvider = services.BuildServiceProvider();


using (var server = serviceProvider.GetRequiredService<BackgroundJobServer>())
{
    Console.WriteLine("Hangfire Server for Verification is started. Press any key to exit...");
    Console.ReadKey();
}

// var tokenRetriever = serviceProvider.GetRequiredService<ITokenRetriever>();
//
// var token = await tokenRetriever.RetrieveToken("krystiansitarek.pl",
//                                                VerificationStrategy.DnsRecord,
//                                                CancellationToken.None);
//
// Console.WriteLine(token);