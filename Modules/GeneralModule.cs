using Discord.Interactions;
using Discord;

namespace Template.Modules;

public class GeneralModule : InteractionModuleBase<SocketInteractionContext>
{
    // Declare application command.
    [SlashCommand("latency", "Display bot latency")]
    public async Task LatencyAsync()
    {
        // Get bot's latency (ms).
        int latency = Context.Client.Latency;

        var embed = new EmbedBuilder()
            .WithTitle("Latency")
            .WithDescription($"{latency} ms")
            .WithColor(Color.Blue)
            .Build();

        await RespondAsync(embed: embed);
    }

    [SlashCommand("avatar", "Get a user avatar")]
    public async Task AvatarAsync(
        [Summary("user", "The user to get avatar")] IUser? user = null)
    {
        // If user was not specified or it is null, replace it with interaction executor.
        user ??= Context.User;

        // Build an embed to respond.
        var embed = new EmbedBuilder()
            .WithTitle($"{user.Username}#{user.Discriminator}")
            .WithImageUrl(user.GetAvatarUrl(size: 4096) ?? user.GetDefaultAvatarUrl())
            .WithColor(Color.Blue)
            .Build();

        // Respond to the interaction.
        await RespondAsync(embed: embed);
    }
}