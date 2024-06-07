using Discord;
using Discord.Addons.Hosting;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.EntityFrameworkCore;
using Template;
using Template.Data;
using Template.Services;

Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddNamedOptions<StartupOptions>();
builder.Services.AddNamedOptions<ReferenceOptions>();

builder.Services.AddSqlite<AppDbContext>(builder.Configuration.GetConnectionString("Default"));

builder.Services.AddDiscordHost((config, _) =>
{
    config.SocketConfig = new DiscordSocketConfig
    {
        LogLevel = LogSeverity.Info,
        GatewayIntents = GatewayIntents.AllUnprivileged,
        LogGatewayIntentWarnings = false,
        UseInteractionSnowflakeDate = false,
        AlwaysDownloadUsers = false,
    };

    config.Token = builder.Configuration.GetSection(StartupOptions.GetSectionName()).Get<StartupOptions>()!.Token;
});

builder.Services.AddInteractionService((config, _) =>
{
    config.LogLevel = LogSeverity.Debug;
    config.DefaultRunMode = RunMode.Async;
    config.UseCompiledLambda = true;
});
builder.Services.AddInteractiveService(config =>
{
    config.LogLevel = LogSeverity.Warning;
    config.DefaultTimeout = TimeSpan.FromMinutes(5);
    config.ProcessSinglePagePaginators = true;
});

builder.Services.AddHostedService<InteractionHandler>();

var host = builder.Build();

await host.MigrateAsync<AppDbContext>();
await host.RunAsync();
