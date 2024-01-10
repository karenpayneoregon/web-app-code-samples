namespace ConstraintViolationsSamples.Classes;
public static class Helpers
{
    public static string AddOrdinal1(this int sender)
    {
        if (sender <= 0) return sender.ToString();
        return (sender % 100) switch
        {
            11 => $"{sender}th",
            12 => $"{sender}th",
            13 => $"{sender}th",
            _ => (sender % 10) switch
            {
                1 => $"{sender}st",
                2 => $"{sender}nd",
                3 => $"{sender}rd",
                _ => $"{sender}th"
            }
        };
    }
    public static string AddOrdinal2(this int sender)
    {
        if (sender <= 0) return sender.ToString();
        switch (sender % 100)
        {
            case 11:
            case 12:
            case 13:
                return sender + "th";
        }

        switch (sender % 10)
        {
            case 1:
                return $"{sender}st";
            case 2:
                return $"{sender}nd";
            case 3:
                return $"{sender}rd";
            default:
                return $"{sender}th";
        }
    }
}
