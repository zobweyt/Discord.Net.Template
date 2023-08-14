using Discord;

namespace Template;

/// <summary>
/// Provides extension methods for <see cref="IUser"/>.
/// </summary>
public static class UserExtensions
{
    /// <summary>
    /// Gets avatar URL or the default one.
    /// </summary>
    /// <param name="user">The user to get avatar URL.</param>
    /// <returns>The avatar URL.</returns>
    public static string GetDisplayAvatarUrl(this IUser user) => user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();
}
