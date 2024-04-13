using Discord.Interactions;

namespace Template;

// TODO: Learn about the post-execution interaction results.

/// <summary>
/// Represents the result of an interaction used to handle it at the <a href="https://docs.discordnet.dev/guides/int_framework/post-execution">post-execution</a>.
/// </summary>
/// <example>
/// Here's how it might be used inside the commands:
/// <code>
/// <![CDATA[
/// [SlashCommand("credits", "Shows information about the app's team.")]
/// public async Task<RuntimeResult> CreditsAsync()
/// {
///     var app = await Context.Client.GetApplicationInfoAsync();
/// 
///     if (app.Team is null)
///         return InteractionResult.FromError("This app doesn't belong to a team!");
/// 
///     await RespondAsync($"Made by {Format.Bold(app.Team.Name)}.");
///     return InteractionResult.FromSuccess();
/// }
/// ]]>
/// </code>
/// </example>
/// <remarks>
/// Initializes a new instance of the <see cref="InteractionResult"/> class.
/// <param name="error">The error code to include in the result.</param>
/// <param name="message">The message to include in the result.</param>
/// </remarks>
public class InteractionResult(InteractionCommandError? error, string message) : RuntimeResult(error, message)
{
    /// <summary>
    /// Creates a successful interaction result with an optional message.
    /// </summary>
    /// <param name="message">The message to include in the response.</param>
    /// <returns>
    /// A new instance of the <see cref="InteractionResult"/> with the specified message.
    /// </returns>
    public static InteractionResult FromSuccess(string? message = null) => new(null, message ?? string.Empty);

    /// <summary>
    /// Creates an unsuccessful interaction result with the specified error and message.
    /// </summary>
    /// <param name="message">The message to include in the response.</param>
    /// <returns>
    /// A new instance of the <see cref="InteractionResult"/> with the
    /// <see cref="InteractionCommandError.Unsuccessful"/> code and message.
    /// </returns>
    public static InteractionResult FromError(string message) => new(InteractionCommandError.Unsuccessful, message);
}
