using Fergun.Interactive.Pagination;

namespace Template.Appearance.Pagination.Lazy;

/// <summary>
/// Represents a lazy paginator that provides enhanced pagination features.
/// </summary>
public class EnhancedLazyPaginator : BaseLazyPaginator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnhancedLazyPaginator"/> class with the
    /// specified builder.
    /// </summary>
    /// <param name="builder">The builder used to configure the paginator.</param>
    public EnhancedLazyPaginator(EnhancedLazyPaginatorBuilder builder)
        : base(builder) { }
}
