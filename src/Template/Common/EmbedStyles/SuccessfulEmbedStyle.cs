using Discord;

namespace Template;

/// <summary>
/// Represents the style of a successful embed.
/// </summary>
public class SuccessfulEmbedStyle : EmbedStyle
{
    /// <inheritdoc/>
    public override string Name => "Succeed!";

    /// <inheritdoc/>
    public override string IconUrl => Icons.Check;

    /// <inheritdoc/>
    public override Color Color => Colors.Success;
}
