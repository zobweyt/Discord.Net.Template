using Discord;

namespace Template.Entities;

/// <summary>
/// Represents an abstract class for defining embed styles.
/// </summary>
public abstract class EmbedStyle
{
    /// <summary>
    /// Gets or sets the name of the embed style.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets or sets the icon URL of the embed style.
    /// </summary>
    public string? IconUrl { get; protected set; }

    /// <summary>
    /// Gets or sets the color of the embed style.
    /// </summary>
    public Color Color { get; protected set; }

    /// <summary>
    /// Applies the embed style to an <see cref="EmbedBuilder"/>.
    /// </summary>
    /// <param name="name">The name of the embed style.</param>
    public abstract void Apply(string? name = null);
}
