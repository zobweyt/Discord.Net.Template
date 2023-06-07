using Discord.Interactions;
using Discord;
using Fergun.Interactive;
using System.Diagnostics;
using System.Reflection;
using Template.Appearance;
using Template.Entities;

namespace Template.Modules;

public class GeneralModule : ModuleBase
{
    public GeneralModule(ILogger<InteractionModuleBase<SocketInteractionContext>> logger, InteractiveService interactive) 
        : base(logger, interactive) { }

    [SlashCommand("info", "Displays information related to the application.")]
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
            .WithColor(Colors.Primary)
            .Build();

        await FollowupAsync(embed: embed);
    }
}
