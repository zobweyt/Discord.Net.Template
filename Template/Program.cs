using Discord;
using Discord.Addons.Hosting;
using Discord.WebSocket;
using Fergun.Interactive;
using Microsoft.EntityFrameworkCore;
using Template.Data;
using Template.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddOptions<LinksOptions>().BindConfiguration(LinksOptions.Links);
        services.AddOptions<StartupOptions>().BindConfiguration(StartupOptions.Startup);
    })
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

        config.Token = context.Configuration.GetSection(StartupOptions.Startup).Get<StartupOptions>().Token;
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

        string? connectionString = context.Configuration.GetConnectionString("Default");

        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("The database connection string must be specified.");

        ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, serverVersion));

        services.AddHostedService<InteractionHandlingService>();
    })
    .Build();

await host.RunAsync();
