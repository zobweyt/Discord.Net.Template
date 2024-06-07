using System.ComponentModel.DataAnnotations;

namespace Template;

/// <summary>
/// Represents the startup options associated with this app.
/// </summary>
public class StartupOptions : INamedOptions
{
    public static string GetSectionName() => "Startup";

    /// <summary>
    /// The Discord app token obtained from the https://discord.com/developers/applications.
    /// </summary>
    [Required]
    public required string Token { get; init; }

    /// <summary>
    /// The ID of a server in Discord used for development of this app.
    /// </summary>
    [Required]
    [RegularExpression("[^0].*", ErrorMessage = "The ID must not be zero")]
    public required ulong DevGuildId { get; init; }
}
