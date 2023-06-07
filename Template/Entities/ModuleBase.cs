using Discord;
using Discord.Interactions;
using Fergun.Interactive;
using Template.Attributes;

namespace Template.Entities;

/// <summary>
/// This class is an abstract implementation of the <see cref="InteractionModuleBase"/> that
/// provides common functionality for all the solution modules.
/// </summary>
[RateLimit]
[RequireContext(ContextType.Guild)]
[RequireBotPermission(ChannelPermission.ViewChannel)]
[RequireBotPermission(ChannelPermission.SendMessages)]
public abstract class ModuleBase : InteractionModuleBase<SocketInteractionContext>
{
    /// <summary>
    /// The logger used by this module.
    /// </summary>
    protected readonly ILogger<InteractionModuleBase<SocketInteractionContext>> _logger;

    /// <summary>
    /// The interactive service used by this module.
    /// </summary>
    protected readonly InteractiveService _interactive;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModuleBase"/> class.
    /// </summary>
    /// <param name="logger">The logger used by this module.</param>
    /// <param name="interactive">The interactive service used by this module.</param>
    protected ModuleBase(ILogger<InteractionModuleBase<SocketInteractionContext>> logger, InteractiveService interactive)
    {
        _logger = logger;
        _interactive = interactive;
    }
}
