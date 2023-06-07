using Template.Appearance;
using Discord;
using Fergun.Interactive;
using Fergun.Interactive.Pagination;

namespace Template.Extensions.Builders;

/// <summary>
/// Provides extension methods for <see cref="PaginatorBuilderExtensions"/>.
/// </summary>
public static class PaginatorBuilderExtensions
{
    /// <summary>
    /// Adds enhanced options to the paginator builder.
    /// </summary>
    /// <typeparam name="TPaginator">The type of the paginator.</typeparam>
    /// <typeparam name="TPaginatorBuilder">The type of the paginator builder.</typeparam>
    /// <param name="builder">The current builder.</param>
    /// <returns>The paginator builder with enhanced options added.</returns>
    public static TPaginatorBuilder WithEnhancedBuilder<TPaginator, TPaginatorBuilder>(
        this PaginatorBuilder<TPaginator, TPaginatorBuilder> builder
    )
        where TPaginator : Paginator
        where TPaginatorBuilder : PaginatorBuilder<TPaginator, TPaginatorBuilder>
    {
        builder
            .WithActionOnCancellation(ActionOnStop.DeleteMessage)
            .WithActionOnTimeout(ActionOnStop.DisableInput)
            .AddOption(Emotes.Backward, PaginatorAction.Backward, ButtonStyle.Secondary)
            .AddOption(Emotes.Exit, PaginatorAction.Exit, ButtonStyle.Secondary)
            .AddOption(Emotes.Forward, PaginatorAction.Forward, ButtonStyle.Secondary)
            .WithFooter(PaginatorFooter.PageNumber);

        return (TPaginatorBuilder)builder;
    }
}
