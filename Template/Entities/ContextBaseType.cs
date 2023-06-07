namespace Template.Entities;

/// <summary>
/// Represents the type of context base for a command or message component.
/// </summary>
public enum ContextBaseType
{
    /// <summary>
    /// The context base is determined based on the command information.
    /// </summary>
    BaseOnSlashCommandInfo,

    /// <summary>
    /// The context base is determined based on the message component custom ID.
    /// </summary>
    BaseOnMessageComponentCustomId
}
