namespace Template;

/// <summary>
/// Represents rate limit information for a specific operation.
/// </summary>
public class RateLimitInfo
{
    private int _count;

    /// <summary>
    /// Initializes a new instance of the <see cref="RateLimitInfo"> class.
    /// </summary>
    /// <param name="limit">The number of requests that can be made.</param>
    /// <param name="span">The time span for which the limit exists.</param>
    public RateLimitInfo(int limit, TimeSpan span)
    {
        Limit = limit;
        Span = span;
    }

    /// <summary>
    /// Gets the current count of requests made.
    /// </summary>
    public int Count
    {
        get => _count;
        private set
        {
            if (value > Limit)
                throw new ArgumentException($"Value must be less than or equal to {Limit}.", nameof(Count));
            _count = value;
        }
    }

    /// <summary>
    /// Gets the number of requests that can be made.
    /// </summary>
    public int Limit { get; init; }

    /// <summary>
    /// Gets a value indicating whether the rate limit has limited.
    /// </summary>
    public bool IsLimited => Limit == Count;

    /// <summary>
    /// Gets a value indicating whether the rate limit has expired.
    /// </summary>
    public bool IsExpired => DateTime.UtcNow >= ExpireAt;

    /// <summary>
    /// Gets the time span for which the rate limit exists.
    /// </summary>
    public TimeSpan Span { get; init; }

    /// <summary>
    /// Gets the expiration date and time of the rate limit.
    /// </summary>
    public DateTimeOffset ExpireAt => InitializedAt + Span;

    /// <summary>
    /// Gets the initialization date and time of the rate limit.
    /// </summary>
    public DateTimeOffset InitializedAt { get; private set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Increments the count of requests made.
    /// </summary>
    public void Increment()
    {
        Count++;
    }

    /// <summary>
    /// Restores the rate limit to its initial state.
    /// </summary>
    public void Restore()
    {
        Count = 0;
        InitializedAt = DateTimeOffset.UtcNow;
    }
}
