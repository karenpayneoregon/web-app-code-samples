using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace AspCoreHelperLibrary;

/// <summary>
/// Provides a custom implementation of <see cref="IDisplayMetadataProvider"/> 
/// to format property names in PascalCase into a more readable format by inserting spaces.
/// </summary>
/// <remarks>
/// This class is designed to enhance the display metadata for properties in an ASP.NET Core MVC application.
/// It modifies the display name of properties by splitting PascalCase names into separate words, 
/// unless a display name is already explicitly provided.
/// </remarks>
public sealed partial class PascalCaseDisplayMetadataProvider : IDisplayMetadataProvider
{
    /// <summary>
    /// Creates and customizes the display metadata for a given model property.
    /// </summary>
    /// <param name="context">
    /// The <see cref="DisplayMetadataProviderContext"/> that provides the context for creating display metadata.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the <paramref name="context"/> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method modifies the display metadata for properties by formatting their names in a more readable way.
    /// Specifically, it splits PascalCase property names into separate words, unless a display name is already explicitly provided.
    /// </remarks>
    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        // Only touch property names, and only when no Display/DisplayName is already supplied.
        if (context.Key.MetadataKind != ModelMetadataKind.Property)
            return;

        var existing = context.DisplayMetadata.DisplayName?.Invoke();
        if (!string.IsNullOrEmpty(existing))
            return;

        context.DisplayMetadata.DisplayName = () => SplitPascalCase(context.Key.Name ?? string.Empty);
    }

    /// <summary>
    /// Splits a PascalCase string into separate words by inserting spaces before capital letters.
    /// </summary>
    /// <param name="sender">The PascalCase string to be split.</param>
    /// <returns>
    /// A string with spaces inserted before capital letters, making the PascalCase string more readable.
    /// If the input string is null, empty, or consists only of whitespace, it is returned unchanged.
    /// </returns>
    private static string SplitPascalCase(string sender)
    {
        if (string.IsNullOrWhiteSpace(sender)) return sender;

        // Insert a space before capital letters that either:
        //  - follow a lowercase/number, or
        //  - start an Upper-lower sequence (handles “UnitPrice”, “IDNumber”, etc.)
        return SplitPascalCaseRegex().Replace(sender, " $1");
    }

    [GeneratedRegex("(?<=.)([A-Z](?=[a-z])|(?<=[a-z0-9])[A-Z])")]
    private static partial Regex SplitPascalCaseRegex();
}
