using Discord;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Data;

/// <summary>
/// Represents a base implementation of common properties for database entities.
/// </summary>
public abstract class DbEntity : IEntity<ulong>
{
    /// <inheritdoc/>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public virtual ulong Id { get; set; }

    /// <summary>
    /// Gets or sets the identity date and time for this object.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual DateTimeOffset IdentityAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets the computed date and time for this object.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public virtual DateTimeOffset ComputedAt { get; set; } = DateTimeOffset.UtcNow;
}
