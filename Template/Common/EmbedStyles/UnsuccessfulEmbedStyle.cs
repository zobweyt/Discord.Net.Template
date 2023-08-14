using Discord;

namespace Template;

/// <summary>
/// Represents the style of an unsuccessful embed.
/// </summary>
public class UnsuccessfulEmbedStyle : EmbedStyle
{
    public override string Name => "Woops!";

    public override string IconUrl => Icons.Cross;

    public override string? Footer => "Please consider the warning and try once again.";

    public override Color Color => Colors.Danger;
}
