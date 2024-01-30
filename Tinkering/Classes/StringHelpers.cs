using System.Text.RegularExpressions;

namespace Tinkering.Classes;

public static class StringHelpers
{
    /// <summary>
    /// Given a string which ends with a number, increment the number by 1
    /// </summary>
    /// <param name="sender">string ending with a number</param>
    /// <returns>string with ending number incremented by 1</returns>
    public static string NextValue(this string sender)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }
}