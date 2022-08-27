using Discord;
using Discord.Addons.Hosting;
using Discord.WebSocket;
using Template.Services;

namespace Template;

internal class Program
{
    private static async Task Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureDiscordHost((context, config) =>
            {
                config.SocketConfig = new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Debug,
                    AlwaysDownloadUsers = true,
                    MessageCacheSize = 200,
                    GatewayIntents = GatewayIntents.All // Enable in discord developer portal.
                };

                // Storing variables in appsettings.json and appsettings.Development.json is not safe.
                // Better use user-secrets for Development and environment variables for Production.
                // You can find the full guide on the repository page.
                config.Token = context.Configuration["Token"];
            })
            .UseInteractionService((context, config) =>
            {
                config.LogLevel = LogSeverity.Debug;
                config.UseCompiledLambda = true;
            })
            .ConfigureServices((context, services) =>
            {
                // Add any other services right here.
                services
                .AddHostedService<InteractionHandler>();
            })
            .Build();

        await host.RunAsync();
    }
}