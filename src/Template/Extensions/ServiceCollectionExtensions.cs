using Fergun.Interactive;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/>.
/// </summary>
internal static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="InteractiveService"/> and optionally configures an <see cref="InteractiveConfig"/> along with the required services.
    /// </summary>
    /// <param name="collection">The service collection to configure.</param>
    /// <param name="action">The delegate for the <see cref="InteractiveConfig"/> that will be used to configure the host.</param>
    /// <exception cref="InvalidOperationException">Thrown if <see cref="InteractiveService"/> is already added to the service collection.</exception>
    public static void AddInteractiveService(this IServiceCollection collection, Action<InteractiveConfig>? action)
    {
        var config = new InteractiveConfig();
        action?.Invoke(config);

        collection.AddSingleton(config);
        collection.AddSingleton<InteractiveService>();
    }
}
