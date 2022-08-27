using Discord.Interactions;
using Discord;

namespace Template.Modules;

public class GeneralModule : InteractionModuleBase<SocketInteractionContext>
{
    // Declare application command (slash command)
    [SlashCommand("latency", "Display bot latency")]
    public async Task LatencyAsync()
    {
        int latency = Context.Client.Latency; // You can pull technical specifications from the client.

        var embed = new EmbedBuilder()
            .WithTitle("Latency")
            .WithDescription($"{latency} ms")
            .WithColor(Color.Blue)
            .Build();

        await RespondAsync(embed: embed);
    }

    [SlashCommand("avatar", "Get a user avatar")]
    public async Task AvatarAsync(
        [Summary("user", "The user to get avatar")] IGuildUser? user = null) // This way you can add summary to your command parameters.
    {
        // If user was not specified or it is null, replace it with interaction executor.
        user ??= Context.User as IGuildUser;

        // Build an embed to respond.
        var embed = new EmbedBuilder()
            .WithTitle($"{user.Username}#{user.Discriminator}")
            .WithImageUrl((user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl()).Replace("128", "4096"))
            .WithColor(Color.Blue)
            .Build();

        // Respond to the interaction.
        await RespondAsync(embed: embed);
    }
}