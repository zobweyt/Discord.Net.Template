using Microsoft.EntityFrameworkCore;
using Template.Data;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IHost"/>.
/// </summary>
internal static class HostExtensions
{
    /// <summary>
    /// Performs database migration for the specified host.
    /// </summary>
    /// <param name="host">The <see cref="IHost"/> instance.</param>
    /// <returns>A task representing the asynchronous migration operation.</returns>
    public static async Task MigrateAsync(this IHost host)
    {
        await using var scope = host.Services.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<TemplateDbContext>();
        var pendingMigrations = await db.Database.GetPendingMigrationsAsync().ConfigureAwait(false);

        if (pendingMigrations.Any())
            await db.Database.MigrateAsync().ConfigureAwait(false);
    }
}
