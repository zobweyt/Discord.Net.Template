using Discord;
using Discord.Addons.Hosting;
using Discord.WebSocket;
using Template.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureDiscordHost((context, config) =>
    {
        config.SocketConfig = new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Debug,
            // Enable the setting below if you use GatewayIntents.GuildMembers
            AlwaysDownloadUsers = false,
            // The setting below allows application to get the reactions or content of a message.
            // Our template does not have such functionality, but that may be useful for you.
            MessageCacheSize = 0,
            GatewayIntents = GatewayIntents.AllUnprivileged, // Configure more at https://discord.com/developers/applications.
            LogGatewayIntentWarnings = false
        };

        string? token = context.Configuration["Token"];

        if (string.IsNullOrEmpty(token))
            throw new ArgumentNullException(nameof(token), "Token is null or empty. Specify it in your config.");

        config.Token = token;
    })
    .UseInteractionService((context, config) =>
    {
        config.LogLevel = LogSeverity.Debug;
        config.UseCompiledLambda = true;
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<InteractionHandlingService>();
    })
    .Build();

await host.RunAsync();
