using System.Reflection;
using Discord.Interactions;
using Discord;
using Microsoft.Extensions.Options;

namespace Template.Modules;

public class GeneralModule(IOptions<LinksOptions> options) : ModuleBase
{
    protected LinksOptions Links => options.Value;

    [SlashCommand("about", "Shows information about the app.")]
    public async Task AboutAsync()
    {
        var app = await Context.Client.GetApplicationInfoAsync();
        
        var embed = new EmbedBuilder()
            .WithTitle(app.Name)
            .WithDescription(app.Description)
            .AddField("Servers", Context.Client.Guilds.Count, true)
            .AddField("Latency", Context.Client.Latency + "ms", true)
            .AddField("Version", Assembly.GetEntryAssembly().GetName().Version.ToString(3), true)
            .WithAuthor(app.Owner.Username, app.Owner.GetDisplayAvatarUrl())
            .WithFooter(string.Join(" · ", app.Tags.Select(t => '#' + t)))
            .WithColor(Colors.Primary)
            .Build();

        var components = new ComponentBuilder()
            .WithLink("Join", Emotes.Logos.Discord, Links.SupportServerUrl)
            .WithLink("Contribute", Emotes.Logos.Github, Links.SourceRepositoryUrl)
            .Build();

        await RespondAsync(embed: embed, components: components);
    }

    // TODO: Define new general commands here.
}
