namespace Template;

/// <summary>
/// Represents named options.
/// </summary>
public interface INamedOptions
{
    /// <summary>
    /// Gets the section name for the options.
    /// </summary>
    static abstract string GetSectionName();
}
