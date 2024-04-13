using Discord;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="EmbedBuilder"/>.
/// </summary>
public static class EmbedBuilderExtensions
{
    /// <summary>
    /// Applies an <see cref="EmbedStyle"/> for the current embed builder.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <param name="style">An <see cref="EmbedStyle"/> to apply.</param>
    /// <returns>The current builder instance with the style applied.</returns>
    public static EmbedBuilder WithStyle(this EmbedBuilder builder, EmbedStyle style)
        => builder.WithAuthor(style.Name, style.IconUrl).WithColor(style.Color);
}
