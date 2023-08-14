using System.Reflection;
using Discord;
using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Options;

namespace Template.Services;

internal sealed class InteractionHandlingService : DiscordClientService
{
    private readonly IServiceProvider _provider;
    private readonly InteractionService _service;
    private readonly IHostEnvironment _environment;
    private readonly ulong _testingGuildId;

    /// <summary>
    /// Initializes a new instance of the <see cref="InteractionHandlingService"/>.
    /// </summary>
    /// <param name="client">The Discord socket client used by this service.</param>
    /// <param name="logger">The logger used by this service.</param>
    /// <param name="provider">The service provider used by this service.</param>
    /// <param name="service">The interaction service used by this service.</param>
    /// <param name="environment">The host environment used by this service.</param>
    /// <param name="options">The options used by this service.</param>
    public InteractionHandlingService(DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, InteractionService service, IHostEnvironment environment, IOptions<StartupOptions> options)
        : base(client, logger)
    {
        _provider = provider;
        _service = service;
        _environment = environment;
        _testingGuildId = options.Value.TestingGuildId;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Client.InteractionCreated += InteractionCreated;
        _service.InteractionExecuted += InteractionExecuted;

        await using var scope = _provider.CreateAsyncScope();

        await _service.AddModulesAsync(Assembly.GetEntryAssembly(), scope.ServiceProvider);

        await Client.WaitForReadyAsync(stoppingToken);
        await RegisterCommandsAsync();
    }

    private async Task RegisterCommandsAsync()
    {
        if (_environment.IsDevelopment())
        {
            await Client.Rest.DeleteAllGlobalCommandsAsync();
            await _service.RegisterCommandsToGuildAsync(_testingGuildId);
            return;
        }

        if (_testingGuildId != 0)
            await Client.Rest.BulkOverwriteGuildCommands(Array.Empty<ApplicationCommandProperties>(), _testingGuildId);
        else
            Logger.LogWarning("Potential duplication of application commands detected.");

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
        if (string.IsNullOrEmpty(result.ErrorReason))
            return;

        var embed = new EmbedBuilder()
            .WithStyle(result.IsSuccess ? new SuccessfulEmbedStyle() : new UnsuccessfulEmbedStyle())
            .WithDescription(result.ErrorReason)
            .Build();

        await context.Interaction.RespondAsync(embed: embed);
    }
}
