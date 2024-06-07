using System.ComponentModel.DataAnnotations;

namespace Template;

/// <summary>
/// Represents the reference options associated with this app.
/// </summary>
public class ReferenceOptions : INamedOptions
{
    public static string GetSectionName() => "Reference";

    /// <summary>
    /// The URL of the support server in Discord.
    /// </summary>
    [Required]
    [Url]
    public required string SupportServerUrl { get; init; }

    /// <summary>
    /// The URL of the source repository.
    /// </summary>
    [Required]
    [Url]
    public required string SourceRepositoryUrl { get; init; }
}
