using System.Text;

namespace EncoderLibrary;

public class Translator
{
    private static Dictionary<char, string> Dictionary() =>
        new()
        {
            { '\u00e1', "&aacute;" },
            { '\u00e9', "&eacute;" },
            { '\u00ed', "&iacute;" },
            { '\u00f3', "&oacute;" },
            { '\u00fa', "&uacute;" },
            { '\u00e0', "&agrave;" },
            { '\u00e8', "&egrave" },
            { '\u00ee', "&icirc;" },
            { '\u00f2', "&ocirc;" },
            { '\u00fb', "&ucirc;" },
            { '\u00c1', "&Aacute;" },
            { '\u00c9', "&Eacute;" },
            { '\u00cd', "&Iacute;" },
            { '\u00d3', "&Oacute;" },
            { '\u00d4', "&Uacute;" },
            { '\u00c0', "&Agrave;" },
            { '\u00c8', "&Egrave;" },
            { '\u00ce', "&Icirc;" },
            { '\u00d2', "&Ocirc;" },
            { '\u00db', "&Ucirc;" }
        };

    public static string EncodeSpanishCharacters(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var output = new StringBuilder(input.Length * 2);
        foreach (var c in input)
        {
            if (Dictionary().TryGetValue(c, out var value))
            {
                output.Append(value);
            }
            else
            {
                output.Append(c);
            }
        }

        return output.ToString();
    }
}
