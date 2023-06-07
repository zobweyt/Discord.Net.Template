using Discord;

namespace Template.Entities;

/// <summary>
/// Represents a type of the <see cref="ISnowflakeEntity"/>.
/// </summary>
public enum SnowflakeEntityType
{
    /// <summary>
    /// Represents a <see cref="IUser"/> type.
    /// </summary>
    User,

    /// <summary>
    /// Represents a <see cref="IChannel"/> type.
    /// </summary>
    Channel,

    /// <summary>
    /// Represents a <see cref="IGuild"/> type.
    /// </summary>
    Guild
}
