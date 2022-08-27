using Discord;
using Discord.Addons.Hosting;
using Discord.Interactions;
using Discord.WebSocket;

namespace Template.Services;

internal sealed partial class InteractionHandler : DiscordClientService
{
    private async Task InteractionCreated(SocketInteraction interaction)
    {
        try
        {
            var context = new SocketInteractionContext(Client, interaction);
            await _service.ExecuteCommandAsync(context, _provider);
        }
        catch (Exception exception)
        {
            // This way you can use logging.
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

        await context.Interaction.RespondAsync(embed: embed).ConfigureAwait(false);
    }
}