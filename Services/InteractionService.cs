using System.Reflection;
using Discord;
using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.Interactions;
using Discord.WebSocket;

namespace Template.Services;

internal sealed partial class InteractionHandler : DiscordClientService
{
    private readonly IServiceProvider _provider;
    private readonly InteractionService _service;
    private readonly IHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public InteractionHandler(DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, InteractionService service, IHostEnvironment environment, IConfiguration configuration)
        : base(client, logger)
    {
        _provider = provider;
        _service = service;
        _environment = environment;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Process the InteractionCreated payloads to execute Application commands.
        Client.InteractionCreated += InteractionCreated;
        // Process the command execution results.
        _service.InteractionExecuted += InteractionExecuted;

        await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);

        await Client.WaitForReadyAsync(stoppingToken);
        // Change bot activity here.
        await Client.SetGameAsync("Discord.NET");
        await RegisterCommandsAsync();
    }

    private async Task RegisterCommandsAsync()
    {
        // If DOTNET_ENVIRONMENT application commands will be registered for DevGuild and global commands will be deleted.
        if (_environment.IsDevelopment())
        {
            await Client.Rest.DeleteAllGlobalCommandsAsync();
            await _service.RegisterCommandsToGuildAsync(_configuration.GetValue<ulong>("DevGuild"));
            return;
        }

        // Otherwise commands will register globally and DevGuild commands will be overwrited (takes up to hour).
        await Client.Rest.BulkOverwriteGuildCommands(Array.Empty<ApplicationCommandProperties>(), _configuration.GetValue<ulong>("DevGuild"));
        await _service.RegisterCommandsGloballyAsync();
    }
}