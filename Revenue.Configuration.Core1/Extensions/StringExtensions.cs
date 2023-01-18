using System.Text.RegularExpressions;

namespace Revenue.Configuration.Core1.Extensions;
internal static class StringExtensions
{
    /// <summary>
    /// Remove extra spaces in a string
    /// </summary>
    /// <param name="sender">string value</param>
    /// <returns>string with no extra spaces</returns>
    public static string RemoveExtraSpaces(this string sender)
    {
        const RegexOptions options = RegexOptions.None;
        var regex = new Regex("[ ]{2,}", options);
        return regex.Replace(sender, " ");
    }

}
