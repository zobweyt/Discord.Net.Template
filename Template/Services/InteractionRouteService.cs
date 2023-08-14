using Discord.Interactions;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Text;

namespace Template.Services;

/// <summary>
/// Service class for binding custom interactions to their corresponding custom IDs.
/// </summary>
public sealed class InteractionRouteService
{
    private readonly string _wildCardExpression;

    /// <summary>
    /// Initializes a new instance of the <see cref="InteractionRouteService"/> class.
    /// </summary>
    /// <param name="options">The options containing the wild card expression.</param>
    public InteractionRouteService(IOptions<InteractionServiceConfig> options)
    {
        _wildCardExpression = options.Value.WildCardExpression;
    }

     /// <summary>
    /// Binds a delegate to its corresponding custom ID by applying any provided arguments.
    /// </summary>
    /// <param name="func">The delegate to bind.</param>
    /// <param name="args">The arguments to apply.</param>
    /// <returns>The custom ID bound with the delegate and arguments applied.</returns>
    public string Bind(Delegate func, params object[] args)
    {
        var sb = new StringBuilder(GetCustomIdPattern(func));

        for (int argPos = 0; argPos < args.Length; argPos++)
            sb.Replace(_wildCardExpression, args[argPos].ToString());

        return sb.ToString();
    }

    /// <summary>
    /// Retrieves the custom ID pattern associated with a delegate.
    /// </summary>
    /// <param name="func">The delegate.</param>
    /// <returns>The custom ID pattern associated with the delegate.</returns>
    /// <exception cref="ArgumentException">Thrown when the provided delegate doesn't have an interaction attribute.</exception>
    public static string GetCustomIdPattern(Delegate func)
    {
        foreach (Attribute attribute in func.Method.GetCustomAttributes())
        {
            switch (attribute)
            {
                case ModalInteractionAttribute modal:
                    return modal.CustomId;
                case ComponentInteractionAttribute component:
                    return component.CustomId;
            }
        }

        throw new ArgumentException("The provided delegate doesn't have an interaction attribute.", nameof(func));
    }
}