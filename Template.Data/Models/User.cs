using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Data.Models;

/// <summary>
/// Represents a user in Discord.
/// </summary>
public class User
{
    /// <summary>
    /// The ID of this user in the database.
    /// </summary>
    public ulong Id { get; set; }

    /// <summary>
    /// The time when this user was added to the database.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// The time when this user was updated in the database.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.UtcNow;
}
