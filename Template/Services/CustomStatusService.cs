using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.WebSocket;
using Fergun.Interactive;

namespace Template.Services;

internal sealed class CustomStatusService : DiscordClientService
{
    private readonly string[] _quotes =
    {
        "Life goes on.",
        "The sky is clear.",
        "Nature is beautiful.",
    };

    private readonly Random _random = new();
    private readonly InteractiveConfig _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomStatusService"/>.
    /// </summary>
    /// <param name="client">The Discord socket client used by this service.</param>
    /// <param name="logger">The logger used by this service.</param>
    /// <param name="config">The interactive config used by this service.</param>
    public CustomStatusService(DiscordSocketClient client, ILogger<DiscordClientService> logger, InteractiveConfig config)
        : base(client, logger)
    {
        _config = config;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Client.WaitForReadyAsync(stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            await Client.SetCustomStatusAsync(_quotes[_random.Next(0, _quotes.Length)]);
            await Task.Delay(_config.DefaultTimeout, stoppingToken);
        }
    }
}