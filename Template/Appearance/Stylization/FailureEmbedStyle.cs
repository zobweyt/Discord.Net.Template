using Template.Entities;

namespace Template.Appearance.Stylization;

/// <summary>
/// Represents the style of a failure embed.
/// </summary>
public class FailureEmbedStyle : EmbedStyle
{
    /// <inheritdoc/>
    public override void Apply(string? name = null)
    {
        Name = name ?? "Failure!";
        IconUrl = Icons.Failure;
        Color = Colors.Danger;
    }
}
