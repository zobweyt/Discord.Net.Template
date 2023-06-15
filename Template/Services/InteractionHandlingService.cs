﻿using System.Reflection;
using Discord;
using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.Interactions;
using Discord.WebSocket;
using Template.Appearance.Stylization;
using Template.Extensions.Builders;

namespace Template.Services;

internal sealed class InteractionHandlingService : DiscordClientService
{
    private readonly IServiceProvider _provider;
    private readonly InteractionService _service;
    private readonly IHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public InteractionHandlingService(DiscordSocketClient client, ILogger<DiscordClientService> logger, IServiceProvider provider, InteractionService service, IHostEnvironment environment, IConfiguration configuration)
        : base(client, logger)
    {
        _provider = provider;
        _service = service;
        _environment = environment;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Process the interaction payloads to execute and handle application commands.
        Client.InteractionCreated += InteractionCreated;
        _service.InteractionExecuted += InteractionExecuted;

        // Required to use the database context in modules.
        // May be fixed by Discord.NET library in the future.
        await using var scope = _provider.CreateAsyncScope();

        await _service.AddModulesAsync(Assembly.GetEntryAssembly(), scope.ServiceProvider);

        // Client must to be ready before doing any actions.
        await Client.WaitForReadyAsync(stoppingToken);
        await Client.SetGameAsync("Discord.NET");
        await RegisterCommandsAsync();
    }

    private async Task RegisterCommandsAsync()
    {
        ulong devGuildId = _configuration.GetValue<ulong>("DevGuild");

        // If "DOTNET_ENVIRONMENT": "Development" commands will be registered to your development guild.
        if (_environment.IsDevelopment())
        {
            await Client.Rest.DeleteAllGlobalCommandsAsync();
            await _service.RegisterCommandsToGuildAsync(devGuildId);
            return;
        }

        if (devGuildId != 0)
        {
            await Client.Rest.BulkOverwriteGuildCommands(Array.Empty<ApplicationCommandProperties>(), devGuildId);
        }
        else
        {
            Logger.LogWarning("Make sure to define the 'DevGuild' in the configuration to prevent duplicate application commands.");
        }

        // Otherwise commands will register globally.
        // Remember that all global operations take up to an hour.
        await _service.RegisterCommandsGloballyAsync();
    }

    private async Task InteractionCreated(SocketInteraction interaction)
    {
        try
        {
            var context = new SocketInteractionContext(Client, interaction);
            await _service.ExecuteCommandAsync(context, _provider);
        }
        catch (Exception exception)
        {
            Logger.LogError(exception, "Exception occurred whilst attempting to handle interaction.");
        }
    }

    private async Task InteractionExecuted(ICommandInfo command, IInteractionContext context, IResult result)
    {
        if (string.IsNullOrEmpty(result.ErrorReason))
            return;

        Embed embed = new EmbedBuilder()
            .WithStyle(result.IsSuccess ? new SuccessEmbedStyle() : new FailureEmbedStyle())
            .WithDescription(result.ErrorReason)
            .Build();

        await context.Interaction.RespondAsync(embed: embed);
    }
}
