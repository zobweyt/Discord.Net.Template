using Discord.Interactions;
using Discord;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Extensions.Options;

namespace Template.Modules;

public class GeneralModule : ModuleBase
{
    private readonly LinksOptions _links;

    public GeneralModule(IOptions<LinksOptions> links)
    {
        _links = links.Value;
    }

    [SlashCommand("about", "Displays information about the application.")]
    public async Task AboutAsync()
    {
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
            .WithColor(Colors.Primary)
            .Build();

        var components = new ComponentBuilder()
            .WithButton("Join", null, ButtonStyle.Link, Emotes.Logos.Discord, _links.Discord)
            .WithButton("Contribute", null, ButtonStyle.Link, Emotes.Logos.Github, _links.Github)
            .Build();

        await FollowupAsync(embed: embed, components: components);
    }
}
