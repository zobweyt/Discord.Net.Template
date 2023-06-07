using Template.Extensions.Builders;
using Fergun.Interactive.Pagination;

namespace Template.Appearance.Pagination.Lazy;

/// <summary>
/// Provides a builder for creating an <see cref="EnhancedLazyPaginator"/>.
/// </summary>
public class EnhancedLazyPaginatorBuilder : BaseLazyPaginatorBuilder<EnhancedLazyPaginator, EnhancedLazyPaginatorBuilder>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnhancedLazyPaginatorBuilder"/> and 
    /// configures it with enhanced settings.
    /// </summary>
    public EnhancedLazyPaginatorBuilder()
    {
        this.WithEnhancedBuilder();
    }

    /// <inheritdoc/>
    public override EnhancedLazyPaginator Build()
    {
        return new(this);
    }
}
