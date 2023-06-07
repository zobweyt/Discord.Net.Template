using Discord;

namespace Template.Entities;

/// <summary>
/// Represents a type of the <see cref="ISnowflakeEntity"/>.
/// </summary>
public enum SnowflakeEntityType
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    User,

    /// <summary>
    /// Represents a channel.
    /// </summary>
    Channel,

    /// <summary>
    /// Represents a guild.
    /// </summary>
    Guild
}
