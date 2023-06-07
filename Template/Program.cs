using Discord;
using Discord.Addons.Hosting;
using Discord.WebSocket;
using Fergun.Interactive;
using Template.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureDiscordHost((context, config) =>
    {
        config.SocketConfig = new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Debug,
            // Enable the setting below to cache users.
            AlwaysDownloadUsers = false,
            // The setting below allows application to get the reactions or content of a message.
            MessageCacheSize = 0,
            // Configure more privileged intents at https://discord.com/developers/applications.
            GatewayIntents = GatewayIntents.AllUnprivileged,
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
        InteractiveConfig interactiveConfig = new()
        {
            LogLevel = LogSeverity.Debug,
            DeferStopPaginatorInteractions = true,
            DefaultTimeout = TimeSpan.FromMinutes(5)
        };

        services.AddSingleton(interactiveConfig);
        services.AddSingleton<InteractiveService>();

        services.AddHostedService<InteractionHandlingService>();
    })
    .Build();

await host.RunAsync();
