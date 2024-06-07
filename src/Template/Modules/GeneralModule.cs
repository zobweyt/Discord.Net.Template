using System.Reflection;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Options;

namespace Template.Modules;

public class GeneralModule(IOptions<ReferenceOptions> options) : ModuleBase
{
    [SlashCommand("about", "Shows information about the app.")]
    public async Task AboutAsync()
    {
        var app = await Context.Client.GetApplicationInfoAsync();

        var embed = new EmbedBuilder()
            .WithTitle(app.Name)
            .WithDescription(app.Description)
            .AddField("Servers", Context.Client.Guilds.Count, true)
            .AddField("Latency", Context.Client.Latency + "ms", true)
            .AddField("Version", Assembly.GetExecutingAssembly().GetName().Version, true)
            .WithAuthor(app.Owner.Username, app.Owner.GetDisplayAvatarUrl())
            .WithFooter(string.Join(" · ", app.Tags.Select(t => '#' + t)))
            .WithColor(Colors.Primary)
            .Build();

        var components = new ComponentBuilder()
            .WithLink("Support", Emotes.Logos.Discord, options.Value.SupportServerUrl)
            .WithLink("Source", Emotes.Logos.Github, options.Value.SourceRepositoryUrl)
            .Build();

        await RespondAsync(embed: embed, components: components);
    }

    // TODO: Define new general commands here.
}
