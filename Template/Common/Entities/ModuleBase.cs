using Discord;
using Discord.Interactions;

namespace Template;

/// <summary>
/// An implementation of the <see cref="InteractionModuleBase"/> for this solution.
/// </summary>
public abstract class ModuleBase : InteractionModuleBase<SocketInteractionContext>
{
    protected virtual async Task RespondWithModalAsync<T>(string customId, Action<ModalBuilder> modifyModal = null, RequestOptions options = null) where T : class, IModal
        => await Context.Interaction.RespondWithModalAsync<T>(customId, options, modifyModal);
}
