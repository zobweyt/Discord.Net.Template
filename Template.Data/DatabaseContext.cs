using Microsoft.EntityFrameworkCore;
using Template.Data.Models;

namespace Template.Data;

/// <summary>
/// An implementation of the <see cref="DbContext"/> for this solution.
/// </summary>
public class DatabaseContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseContext"/>.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options) { }

    /// <summary>
    /// Gets or sets the user entities.
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;
}
