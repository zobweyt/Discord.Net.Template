using Discord;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="ComponentBuilder"/>.
/// </summary>
public static class ComponentBuilderExtensions
{
    /// <summary>
    /// Adds a button with <see cref="ButtonStyle.Link"/> style to the component builder.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="label">The label text.</param>
    /// <param name="emote">An emote to be used with this link.</param>
    /// <param name="url">The URL of this link.</param>
    /// <returns>The current builder.</returns>
    public static ComponentBuilder WithLink(this ComponentBuilder builder, string label, Emote emote, string url)
    {
        var button = new ButtonBuilder()
            .WithLabel(label)
            .WithStyle(ButtonStyle.Link)
            .WithUrl(url)
            .WithEmote(emote);

        return builder.WithButton(button);
    }
}
