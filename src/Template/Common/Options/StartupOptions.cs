namespace Template;

/// <summary>
/// The startup options associated with this application.
/// </summary>
public class StartupOptions
{
    /// <summary>
    /// The path to the configuration section.
    /// </summary>
    public const string Startup = nameof(Startup);

    /// <summary>
    /// The Discord application token obtained from the https://discord.com/developers/applications.
    /// </summary>
    public required string Token { get; init; }

    /// <summary>
    /// The ID of a server in the Discord used for development of this application.
    /// </summary>
    public ulong DevGuildId { get; init; }
}
