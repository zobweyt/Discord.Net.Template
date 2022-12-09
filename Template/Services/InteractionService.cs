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
        // Process the interaction payloads to execute and handle application commands.
        Client.InteractionCreated += InteractionCreated;
        _service.InteractionExecuted += InteractionExecuted;

        await _service.AddModulesAsync(Assembly.GetEntryAssembly(), _provider);

        // Client must to be ready before doing any actions.
        await Client.WaitForReadyAsync(stoppingToken);
        await Client.SetGameAsync("Discord.NET");
        await RegisterCommandsAsync();
    }

    private async Task RegisterCommandsAsync()
    {
        // If "DOTNET_ENVIRONMENT": "Development" commands will be registered to your development guild.
        if (_environment.IsDevelopment())
        {
            await Client.Rest.DeleteAllGlobalCommandsAsync();
            await _service.RegisterCommandsToGuildAsync(_configuration.GetValue<ulong>("DevGuild"));
            return;
        }

        // Otherwise commands will register globally.
        // Remember that all global operations take up to an hour.
        await Client.Rest.BulkOverwriteGuildCommands(Array.Empty<ApplicationCommandProperties>(), _configuration.GetValue<ulong>("DevGuild"));
        await _service.RegisterCommandsGloballyAsync();
    }

    private async Task InteractionCreated(SocketInteraction interaction)
    {
        try
        {
            var context = new SocketInteractionContext(Client, interaction);
            await _service.ExecuteCommandAsync(context, _provider);
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "Exception occurred whilst attempting to handle interaction.");
        }
    }

    private async Task InteractionExecuted(ICommandInfo command, IInteractionContext context, IResult result)
    {
        if (result.IsSuccess)
            return;

        // Handle error execution result here.
        var embed = new EmbedBuilder()
            .WithTitle("Error!")
            .WithDescription(result.ErrorReason)
            .WithColor(Color.Red)
            .Build();

        await context.Interaction.RespondAsync(embed: embed);
    }
}