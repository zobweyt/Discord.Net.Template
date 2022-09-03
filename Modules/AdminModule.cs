using Discord;
using Discord.Interactions;

namespace Template.Modules;

[RequireContext(ContextType.Guild)]
[RequireUserPermission(GuildPermission.Administrator)]
public class AdminModule : InteractionModuleBase<SocketInteractionContext>
{
    // If the bot does not have the rights described below, then the error is processed in InteractionHandler.
    [RequireBotPermission(ChannelPermission.ManageMessages)]
    [SlashCommand("clean", "Delete multiple channel messages")]
    public async Task CleanAsync(
        [Summary("amount", $"The number of messages to clean up.")] int amount)
    {
        // Respond to the interaction with expectation without text.
        await Context.Interaction.DeferAsync();

        var messages = await Context.Channel.GetMessagesAsync(amount + 1).FlattenAsync(); 
        // Due to Discord's limits, it is only possible to delete messages which are less than two weeks old.
        var youngMessages = messages.Skip(1).Where(x => x.Timestamp > DateTime.Now.AddDays(-14));
        await (Context.Channel as ITextChannel).DeleteMessagesAsync(youngMessages);

        var embed = new EmbedBuilder()
            .WithTitle("Success!")
            .WithDescription($"{youngMessages.Count()} messages have been successfully cleaned.")
            .WithColor(Color.Green)
            .Build();

        // Because we used DeferAsync(), now we should update the interaction.
        await ModifyOriginalResponseAsync(x => x.Embed = embed);
    }
}