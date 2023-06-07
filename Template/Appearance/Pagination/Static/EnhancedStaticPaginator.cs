using Fergun.Interactive.Pagination;

namespace Template.Appearance.Pagination.Static;

/// <summary>
/// Represents a static paginator that provides enhanced pagination features.
/// </summary>
public class EnhancedStaticPaginator : BaseStaticPaginator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnhancedStaticPaginator"/> class with the
    /// specified builder.
    /// </summary>
    /// <param name="builder">The builder used to configure the paginator.</param>
    public EnhancedStaticPaginator(EnhancedStaticPaginatorBuilder builder)
        : base(builder) { }
}
