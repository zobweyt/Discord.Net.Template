using Template.Entities;

namespace Template.Appearance.Stylization;

/// <summary>
/// Represents the style of a success embed.
/// </summary>
public class SuccessEmbedStyle : EmbedStyle
{
    /// <inheritdoc/>
    public override void Apply(string? name = null)
    {
        Name = name ?? "Success!";
        IconUrl = Icons.Success;
        Color = Colors.Success;
    }
}
