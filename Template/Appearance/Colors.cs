using Discord;

namespace Template.Appearance;

/// <summary>
/// Represents a constant set of predefined <see cref="Color"/> values.
/// </summary>
public static class Colors
{
    /// <summary>
    /// The color used to indicate an informative state.
    /// </summary>
    public static readonly Color Primary = new(14, 96, 194);

    /// <summary>
    /// The color used to depict an emotion of positivity.
    /// </summary>
    public static readonly Color Success = new(43, 182, 115);

    /// <summary>
    /// The color used to depict an emotion of negativity.
    /// </summary>
    public static readonly Color Danger = new(231, 76, 60);
}
