using System.Text.RegularExpressions;

namespace Tinkering.Classes;

public static partial class StringHelpers
{
    /// <summary>
    /// Given a string which ends with a number, increment the number by 1
    /// </summary>
    /// <param name="sender">string ending with a number</param>
    /// <returns>string with ending number incremented by 1</returns>
    public static string NextValue(this string sender)
    {
        string value = TrailingNumberRegex().Match(sender).Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }

    [GeneratedRegex("[0-9]+$")]
    private static partial Regex TrailingNumberRegex();
}