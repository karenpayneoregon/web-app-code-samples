using System.Text;

namespace TransformerSlugs.Classes;

public static class Extensions
{
    public static string ToSlug(this string value, bool toLower = true)
    {
        if (value == null)
        {
            return "";
        }

        var normalized = value.Normalize(NormalizationForm.FormKD);

        const int maxLen = 80;
        int len = normalized.Length;
        bool prevDash = false;
        var sb = new StringBuilder(len);
        char c;

        for (int i = 0; i < len; i++)
        {
            c = normalized[i];
            if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
            {
                if (prevDash)
                {
                    sb.Append('-');
                    prevDash = false;
                }
                sb.Append(c);
            }
            else if (c >= 'A' && c <= 'Z')
            {
                if (prevDash)
                {
                    sb.Append('-');
                    prevDash = false;
                }
                // Tricky way to convert to lowercase
                if (toLower)
                {
                    sb.Append((char)(c | 32));
                }
                else
                {
                    sb.Append(c);
                }
            }
            else if (c == ' ' || c == ',' || c == '.' || c == '/' || c == '\\' || c == '-' || c == '_' || c == '=')
            {
                if (!prevDash && sb.Length > 0)
                {
                    prevDash = true;
                }
            }
            else
            {
                string swap = ConvertEdgeCases(c, toLower);
                if (swap != null)
                {
                    if (prevDash)
                    {
                        sb.Append('-');
                        prevDash = false;
                    }
                    sb.Append(swap);
                }
            }
            if (sb.Length == maxLen)
                break;
        }

        return sb.ToString();
    }
    static string ConvertEdgeCases(char c, bool toLower)
    {
        string swap = null!;
        switch (c)
        {
            case 'ı':
                swap = "i";
                break;
            case 'ł':
                swap = "l";
                break;
            case 'Ł':
                swap = toLower ? "l" : "L";
                break;
            case 'đ':
                swap = "d";
                break;
            case 'ß':
                swap = "ss";
                break;
            case 'ø':
                swap = "o";
                break;
            case 'Þ':
                swap = "th";
                break;
        }
        return swap!;
    }
}
