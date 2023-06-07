using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Template.Entities;
using System.Collections.Concurrent;

namespace Template.Attributes;

/// <summary>
/// Specifies that a slash command is subject to rate limiting.
/// </summary>
/// <remarks>
/// Use this attribute to restrict the rate at which a slash command can be used.
/// You can specify the duration of the rate limit, the maximum number of requests
/// within that duration, and the type of context to apply the rate limit to.
/// </remarks>
public sealed class RateLimitAttribute : PreconditionAttribute
{
    /// <summary>
    /// Represents a rate limit for a specific context.
    /// </summary>
    /// <param name="ContextId">The ID of the context that the rate limit applies to.</param>
    /// <param name="ExpireAt">The time at which the rate limit expires.</param>
    public record RateLimit(string? ContextId, DateTime ExpireAt);

    /// <summary>
    /// A dictionary of rate limits for each entity.
    /// </summary>
    private ConcurrentDictionary<ulong, List<RateLimit>> RateLimits { get; set; } = new();

    /// <summary>
    /// Gets or sets the type of entity to apply the rate limit to.
    /// </summary>
    private readonly SnowflakeEntityType _snowflakeEntityType;

    /// <summary>
    /// Gets or sets the type of context to apply the rate limit to.
    /// </summary>
    private readonly ContextBaseType _contextBaseType;

    /// <summary>
    /// Gets or sets the maximum number of times the command can be used within the duration.
    /// </summary>
    private readonly int _maxUsageCount;

    /// <summary>
    /// Gets or sets the duration of the rate limit in seconds.
    /// </summary>
    private readonly int _duration;

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitAttribute"/>.
    /// </summary>
    /// <param name="duration">The duration of the rate limit in seconds.</param>
    /// <param name="maxUsageCount"> The maximum of times the slash command could be used in the context within the duration.</param>
    /// <param name="snowflakeEntityType">The type of entity to apply the rate limit to.</param>
    /// <param name="contextBaseType">The type of context to apply the rate limit to.</param>
    public RateLimitAttribute(int duration = 4, int maxUsageCount = 1, SnowflakeEntityType snowflakeEntityType = SnowflakeEntityType.User, ContextBaseType contextBaseType = ContextBaseType.BaseOnSlashCommandInfo)
    {
        _snowflakeEntityType = snowflakeEntityType;
        _maxUsageCount = maxUsageCount;
        _duration = duration;
        _contextBaseType = contextBaseType;
    }

    /// <inheritdoc/>
    public override async Task<PreconditionResult> CheckRequirementsAsync(
        IInteractionContext context,
        ICommandInfo commandInfo,
        IServiceProvider serviceProvider
    )
    {
        var application = await context.Client.GetApplicationInfoAsync();
        
        if (context.User.Id == application.Owner.Id)
        {
            return PreconditionResult.FromSuccess();
        }

        DateTime now = DateTime.UtcNow;
        DateTime expireAt = now.AddSeconds(_duration);

        ulong snowflakeEntityId = GetSnowflakeEntityId(context);
        string contextId = GetContextId(context, commandInfo);

        var rateLimits = RateLimits.GetOrAdd(snowflakeEntityId, new List<RateLimit>());
        var contextRateLimits = rateLimits.FindAll(x => x.ContextId == contextId);

        foreach (var contextRateLimit in contextRateLimits)
        {
            if (now >= contextRateLimit.ExpireAt)
            {
                rateLimits.Remove(contextRateLimit);
            }
        }

        if (contextRateLimits.Count >= _maxUsageCount)
        {
            var timestamp = $"<t:{((DateTimeOffset)expireAt).ToUnixTimeSeconds()}:T>";

            return PreconditionResult.FromError($"You are being rate limited until {timestamp}.");
        }
        else
        {
            rateLimits.Add(new RateLimit(contextId, expireAt));
        }

        return PreconditionResult.FromSuccess();
    }

    /// <summary>
    /// Generates a context ID based on the specified interaction context and command info.
    /// </summary>
    /// <param name="context">The interaction context.</param>
    /// <param name="commandInfo">The command info.</param>
    /// <returns>The context ID.</returns>
    private string GetContextId(IInteractionContext context, ICommandInfo commandInfo)
    {
        return _contextBaseType switch
        {
            ContextBaseType.BaseOnSlashCommandInfo => $"{commandInfo.Module.Name}:{commandInfo.MethodName}:{commandInfo.Name}",
            ContextBaseType.BaseOnMessageComponentCustomId => ((SocketMessageComponent)context.Interaction).Data.CustomId,
            _ => throw new ArgumentOutOfRangeException(nameof(_contextBaseType), $"Cannot find {typeof(ContextBaseType)} case for this entity.")
        };
    }

    /// <summary>
    /// Gets the snowflake entity ID based on the specified interaction context.
    /// </summary>
    /// <param name="context">The interaction context.</param>
    /// <returns>The snowflake entity ID.</returns>
    private ulong GetSnowflakeEntityId(IInteractionContext context)
    {
        return _snowflakeEntityType switch
        {
            SnowflakeEntityType.User => context.User.Id,
            SnowflakeEntityType.Channel => context.Channel.Id,
            SnowflakeEntityType.Guild => context.Guild.Id,
            _ => throw new ArgumentOutOfRangeException(nameof(_snowflakeEntityType), $"Cannot find {typeof(SnowflakeEntityType)} case for this entity.")
        };
    }
}
