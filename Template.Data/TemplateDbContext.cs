using Microsoft.EntityFrameworkCore;

namespace Template.Data;

/// <summary>
/// An implementation of the <see cref="DbContext"/> for this solution.
/// </summary>
public class TemplateDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TemplateDbContext"/>.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
        : base(options) { }
}
