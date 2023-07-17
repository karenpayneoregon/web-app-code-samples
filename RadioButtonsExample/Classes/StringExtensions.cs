using static System.Text.RegularExpressions.Regex;

namespace RadioButtonsExample.Classes;


public static class StringExtensions
{
    public static string PrependType(this string sender, string token) 
        => $"{sender} {token}";

    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
}
