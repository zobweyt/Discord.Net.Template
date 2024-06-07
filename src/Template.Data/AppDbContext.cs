using Microsoft.EntityFrameworkCore;

namespace Template.Data;

/// <summary>
/// An implementation of the <see cref="DbContext"/> for this solution.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AppDbContext"/>.
/// </remarks>
/// <param name="options">The options for this context.</param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // TODO: Configure the database context.
    // Learn more at the https://learn.microsoft.com/ef/core.
}
