using Discord;
using Discord.Interactions;

namespace Template.Modules;

[RequireContext(ContextType.Guild)]
[RequireUserPermission(GuildPermission.Administrator)]
public class AdminModule : InteractionModuleBase<SocketInteractionContext>
{
    [RequireBotPermission(ChannelPermission.ManageMessages)]
    [SlashCommand("clean", "Delete multiple channel messages")]
    public async Task CleanAsync(
        [Summary("amount", $"The number of messages to clean up.")][MinValue(2), MaxValue(100)] int amount)
    {
        if (Context.Channel is not ITextChannel channel)
            return;

        // Respond to the interaction without text.
        await Context.Interaction.DeferAsync();

        var messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync(); 
        // Due to Discord's limits, it is only possible to delete messages which are less than two weeks old.
        var youngMessages = messages.Skip(1).Where(x => x.Timestamp > DateTime.Now.AddDays(-14));
        await channel.DeleteMessagesAsync(youngMessages);

        var embed = new EmbedBuilder()
            .WithTitle("Success!")
            .WithDescription($"{youngMessages.Count()} messages have been successfully cleaned.")
            .WithColor(Color.Green)
            .Build();

        // Use FollowupAsync to send a followup message to the interaction.
        await FollowupAsync(embed: embed);
    }
}