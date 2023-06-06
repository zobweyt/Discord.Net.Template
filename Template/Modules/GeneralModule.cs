using Discord.Interactions;
using Discord;
using System.Diagnostics;
using System.Reflection;

namespace Template.Modules;

public class GeneralModule : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("info", "Displays information about the bot.")]
    public async Task InfoAsync()
    {
        await DeferAsync();
        
        string location = Assembly.GetExecutingAssembly().Location;
        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(location);
        IApplication application = await Context.Client.GetApplicationInfoAsync();

        var embed = new EmbedBuilder()
            .WithTitle(application.Name)
            .WithDescription(application.Description)
            .AddField("Guilds", Context.Client.Guilds.Count, true)
            .AddField("Latency", Context.Client.Latency, true)
            .AddField("Version", fileVersionInfo.ProductVersion, true)
            .WithThumbnailUrl(application.IconUrl)
            .WithColor(Color.Blue)
            .Build();

        await FollowupAsync(embed: embed);
    }
}
