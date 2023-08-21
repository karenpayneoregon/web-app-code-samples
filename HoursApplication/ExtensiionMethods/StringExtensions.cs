using static System.Text.RegularExpressions.Regex;
namespace HoursApplication.ExtensiionMethods;

public static class StringExtensions
{
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));
}
