using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FluentWebApplication.Classes.MetadataProviders.Html;

/// <summary>
/// Provides extension methods for rendering display names in HTML views.
/// </summary>
/// <remarks>
/// Must be added to _ViewImports.cshtml:
/// </remarks>
public static class HtmlDisplayNameExtensions
{
    /// <summary>
    /// Retrieves the display name for the specified model property, excluding any trailing asterisk (*).
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TValue">The type of the property value.</typeparam>
    /// <param name="html">The HTML helper instance that this method extends.</param>
    /// <param name="expression">An expression identifying the property for which to retrieve the display name.</param>
    /// <returns>An <see cref="IHtmlContent"/> containing the display name without a trailing asterisk.</returns>
    /// <remarks>
    /// This method is useful for scenarios where display names are automatically suffixed with an asterisk 
    /// (e.g., to indicate required fields) but the asterisk needs to be excluded in the rendered output.
    /// </remarks>
    public static IHtmlContent DisplayNameWithoutStarFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
        var displayName = html.DisplayNameFor(expression) ?? string.Empty;

        if (displayName.EndsWith(" *", StringComparison.Ordinal))
            displayName = displayName[..^2];

        return new HtmlString(displayName);
    }
}

