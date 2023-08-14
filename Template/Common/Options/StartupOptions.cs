namespace Template;

public class StartupOptions
{
    public const string Startup = nameof(Startup);

    public string Token { get; init; } = string.Empty;
    public ulong TestingGuildId { get; init; }
}
