using System.Reflection;
using Discord;
using Discord.Addons.Hosting;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Options;

namespace Template.Services;

internal sealed class InteractionHandler(DiscordSocketClient client, ILogger<InteractionHandler> logger, IServiceProvider provider, InteractionService service, IHostEnvironment environment, IOptions<StartupOptions> options) : DiscordClientService(client, logger)
{
    private readonly ulong _devGuildId = options.Value.DevGuildId;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Client.Ready += RegisterCommandsAsync;
        Client.InteractionCreated += InteractionCreated;

        await using var scope = provider.CreateAsyncScope();
        await service.AddModulesAsync(Assembly.GetEntryAssembly(), scope.ServiceProvider);

        service.InteractionExecuted += InteractionExecuted;
    }

    private async Task RegisterCommandsAsync()
    {
        Logger.LogInformation("Registering commands...");

        if (environment.IsDevelopment())
            await RegisterCommandsLocallyAsync();
        else
            await RegisterCommandsGloballyAsync();

        Logger.LogInformation("Commands have been registered!");
    }

    private async Task RegisterCommandsLocallyAsync()
    {
        await Client.Rest.DeleteAllGlobalCommandsAsync();
        await service.RegisterCommandsToGuildAsync(_devGuildId);
    }

    private async Task RegisterCommandsGloballyAsync()
    {
        if (_devGuildId != 0)
            await Client.Rest.BulkOverwriteGuildCommands([], _devGuildId);
        else
            Logger.LogWarning("Potential duplication of application commands detected.");

        await service.RegisterCommandsGloballyAsync();
    }

    private async Task InteractionCreated(SocketInteraction interaction)
    {
        try
        {
            var context = new SocketInteractionContext(Client, interaction);
            await service.ExecuteCommandAsync(context, provider);
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

        await context.Interaction.HandleWithResultAsync(result);
    }
}
