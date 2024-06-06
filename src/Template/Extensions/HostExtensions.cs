using Microsoft.EntityFrameworkCore;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IHost"/>.
/// </summary>
public static class HostExtensions
{
    /// <summary>
    /// Asynchronously applies any pending migrations for the specified database context.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the database context to apply migrations for.</typeparam>
    /// <param name="host">The host that provides access to the application's services.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task MigrateAsync<TDbContext>(this IHost host)
        where TDbContext : DbContext
    {
        await using var scope = host.Services.CreateAsyncScope();

        var db = scope.ServiceProvider.GetRequiredService<TDbContext>();
        var migrations = await db.Database.GetPendingMigrationsAsync();

        if (!migrations.Any())
            return;

        db.Database.Migrate();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Applied {count} pending database migration(s).", migrations.Count());
    }
}
