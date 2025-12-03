using System.Text.RegularExpressions;

namespace NotesRazorApp.Classes;

public static partial class StringExtensions
{
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", CamelCaseRegex().Matches(sender)
            .Select(m => m.Value));
    
    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex CamelCaseRegex();
}