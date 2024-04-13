using Discord;
using Discord.Interactions;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IDiscordInteraction"/>.
/// </summary>
public static class DiscordInteractionExtensions
{
    /// <summary>
    /// Handles the interaction by sending a response or follow-up message based on the <paramref name="result"/>.
    /// </summary>
    /// <param name="interaction">The interaction to handle.</param>
    /// <param name="result">The result of an operation, which determines the style and description of the embed message.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task HandleWithResultAsync(this IDiscordInteraction interaction, IResult result)
    {
        var embed = new EmbedBuilder()
            .WithStyle(result.IsSuccess ? new SuccessfulEmbedStyle() : new UnsuccessfulEmbedStyle())
            .WithDescription(result.ErrorReason)
            .Build();

        if (interaction.HasResponded)
            await interaction.FollowupAsync(embed: embed).ConfigureAwait(false);
        else
            await interaction.RespondAsync(embed: embed).ConfigureAwait(false);
    }
}
