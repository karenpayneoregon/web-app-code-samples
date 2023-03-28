using System.Text.RegularExpressions;

namespace CheckboxAriaApplication.Classes;

public static class StringExtensions
{
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
    public static string SplitCamelCase(this string sender, string separator) =>
        string.Join(separator, Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
}


