using Template.Extensions.Builders;
using Fergun.Interactive.Pagination;

namespace Template.Appearance.Pagination.Static;

/// <summary>
/// Provides a builder for creating an <see cref="EnhancedStaticPaginator"/>.
/// </summary>
public class EnhancedStaticPaginatorBuilder : BaseStaticPaginatorBuilder<EnhancedStaticPaginator, EnhancedStaticPaginatorBuilder>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnhancedStaticPaginatorBuilder"/> and 
    /// configures it with enhanced settings.
    /// </summary>
    public EnhancedStaticPaginatorBuilder()
    {
        this.WithEnhancedBuilder();
    }

    /// <inheritdoc/>
    public override EnhancedStaticPaginator Build()
    {
        return new(this);
    }
}
