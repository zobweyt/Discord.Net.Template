using Discord;

namespace Template.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IUser"/>.
/// </summary>
public static class IUserExtensions
{
    /// <summary>
    /// Gets avatar URL or the default one.
    /// </summary>
    /// <param name="user">The user to get avatar URL.</param>
    /// <returns>The avatar URL.</returns>
    public static string GetAvatarOrDefaultUrl(this IUser user)
    {
        return user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();
    }
}
