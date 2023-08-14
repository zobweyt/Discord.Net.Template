using Fergun.Interactive;
using Microsoft.EntityFrameworkCore;
using Template.Data;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IHostBuilder"/>.
/// </summary>
internal static class HostBuilderExtensions
{
    /// <summary>
    /// Adds <see cref="InteractiveService"/> and optionally configures an <see cref="InteractiveConfig"/> along with the required services.
    /// </summary>
    /// <param name="builder">The host builder to configure.</param>
    /// <param name="action">The delegate for the <see cref="InteractiveConfig"/> that will be used to configure the host.</param>
    /// <returns>The generic host builder.</returns>
    public static IHostBuilder UseInteractiveService(this IHostBuilder builder, Action<HostBuilderContext, InteractiveConfig>? action = null)
    {
        return builder.ConfigureServices((context, collection) =>
        {
            InteractiveConfig config = new();
            action?.Invoke(context, config);

            collection.AddSingleton(config);
            collection.AddSingleton<InteractiveService>();
        });
    }

    /// <summary>
    /// Adds <see cref="ChaserDbContext"/> and optionally configures its <see cref="DbContextOptions"/> along with the required services.
    /// </summary>
    /// <param name="hostBuilder">The host builder to configure.</param>
    /// <param name="action">The delegate for the <see cref="DbContextOptionsBuilder"/> that will be used to configure the database.</param>
    /// <returns>The generic host builder.</returns>
    public static IHostBuilder ConfigureDatabase(this IHostBuilder hostBuilder, Action<HostBuilderContext, DbContextOptionsBuilder> action)
    {
        return hostBuilder.ConfigureServices((context, collection) =>
        {
            collection.AddDbContext<TemplateDbContext>(options => action?.Invoke(context, options));
        });
    }
}
