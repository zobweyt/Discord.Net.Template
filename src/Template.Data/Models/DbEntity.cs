using System.ComponentModel.DataAnnotations.Schema;
using Discord;

namespace Template.Data;

/// <summary>
/// Represents a base implementation of common properties for database entities.
/// </summary>
public abstract class DbEntity : IEntity<ulong>
{
    /// <inheritdoc/>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public virtual ulong Id { get; init; }

    /// <summary>
    /// Gets the identity date and time for this object.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual DateTimeOffset IdentityAt { get; init; } = DateTimeOffset.UtcNow;
}
