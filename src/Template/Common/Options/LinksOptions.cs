using System.ComponentModel.DataAnnotations;

namespace Template;

/// <summary>
/// The links options associated with this application.
/// </summary>
public class LinksOptions
{
    /// <summary>
    /// The path to the configuration section.
    /// </summary>
    public const string Links = nameof(Links);

    /// <summary>
    /// The URL of the support server in the Discord.
    /// </summary>
    [Url]
    public required string SupportServerUrl { get; init; }

    /// <summary>
    /// The URL of the source repository.
    /// </summary>
    [Url]
    public required string SourceRepositoryUrl { get; init; }
}
