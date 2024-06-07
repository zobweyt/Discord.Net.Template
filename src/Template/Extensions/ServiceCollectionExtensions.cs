using Fergun.Interactive;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/>.
/// </summary>
internal static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="InteractiveService"/> and optionally configures an <see cref="InteractiveConfig"/> along with
    /// the required services.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="action">
    /// The delegate for the <see cref="InteractiveConfig"/> that will be used to configure the host.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if <see cref="InteractiveService"/> is already added to the service collection.
    /// </exception>
    public static void AddInteractiveService(this IServiceCollection services, Action<InteractiveConfig>? action)
    {
        var config = new InteractiveConfig();
        action?.Invoke(config);

        services.AddSingleton(config);
        services.AddSingleton<InteractiveService>();
    }

    /// <summary>
    /// Adds <typeparamref name="TNamedOptions"/>, binds it to configuration, and validates the bound instance.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    public static void AddNamedOptions<TNamedOptions>(this IServiceCollection services)
        where TNamedOptions : class, INamedOptions
    {
        services.AddOptions<TNamedOptions>()
            .BindConfiguration(TNamedOptions.GetSectionName())
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}
