using Discord;
using Discord.Interactions;
using System.Collections.Concurrent;

namespace Template;

/// <summary>
/// Use this attribute to restrict the rate at which an interaction can be used.
/// </summary>
public sealed class RateLimitAttribute : PreconditionAttribute
{
    private readonly int _max;
    private readonly TimeSpan _span;
    private readonly ConcurrentDictionary<string, RateLimitInfo> _cache = new();
    private static ulong? _ownerId;

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitAttribute"/>.
    /// </summary>
    /// <param name="max">The times an interaction can be executed within <paramref name="span"/>.</param>
    /// <param name="span">Specifies how often the executions are permitted.</param>
    /// <param name="measure">The measure of <paramref name="span"/> is interpreted to be.</param>
    public RateLimitAttribute(int max, double span, TimeMeasure measure = TimeMeasure.Seconds)
    {
        _max = max;
        _span = measure switch
        {
            TimeMeasure.Seconds => TimeSpan.FromSeconds(span),
            TimeMeasure.Minutes => TimeSpan.FromMinutes(span),
            TimeMeasure.Hours => TimeSpan.FromHours(span),
            _ => throw new ArgumentException("Invalid time measure value.", nameof(measure))
        };
    }

    public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
    {
        ulong userId = context.User.Id;
        _ownerId ??= (await context.Client.GetApplicationInfoAsync()).Owner.Id;

        if (userId == _ownerId)
            return PreconditionResult.FromSuccess();

        string key = $"{userId}:{commandInfo.Module.Name}:{commandInfo.MethodName}:{commandInfo.Name}";
        RateLimitInfo rateLimitInfo = _cache.GetOrAdd(key, new RateLimitInfo(_max, _span));

        if (rateLimitInfo.IsExpired)
            rateLimitInfo.Restore();
        else if (rateLimitInfo.IsLimited)
            return PreconditionResult.FromError($"You're being limited! This expire {TimestampTag.FromDateTimeOffset(rateLimitInfo.ExpireAt, TimestampTagStyles.Relative)}!");

        rateLimitInfo.Increment();
        return PreconditionResult.FromSuccess();
    }
}
