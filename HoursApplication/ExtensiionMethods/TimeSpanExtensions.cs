namespace HoursApplication.ExtensiionMethods;

public static class TimeSpanExtensions
{
    /// <summary>
    /// Format with hh:mm tt
    /// </summary>
    public static string FormatAmPm(this TimeSpan sender, string format = "hh:mm tt")
        => DateTime.Today.Add(sender).ToString(format);
}