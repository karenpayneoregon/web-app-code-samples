namespace HoursApplication.Classes;

public class Hours
{
    /// <summary>
    /// Creates an list quarter hours
    /// </summary>
    public static List<HourItem> Quarterly => Range(TimeIncrement.Quarterly);
    /// <summary>
    /// Creates an list of hours
    /// </summary>
    public static List<HourItem> Hourly => Range();
    /// <summary>
    /// Creates an list of half-hours
    /// </summary>
    public static List<HourItem> HalfHour => Range(TimeIncrement.HalfHour);

    public static List<HourItem> UserChoice(TimeIncrement timeIncrement) => Range(timeIncrement);

    private static string TimeFormat { get; set; } = "hh:mm tt";

    public static List<HourItem> Range(TimeIncrement timeIncrement = TimeIncrement.Hourly)
    {

        IEnumerable<DateTime> hours = Enumerable.Range(0, 24).Select((index) => (DateTime.MinValue.AddHours(index)));

        var hoursList = new List<HourItem> { new() {Text ="Select", Id = -1, TimeSpan = null} };
        foreach (var dateTime in hours)
        {

            hoursList.Add(new HourItem() { Text = dateTime.ToString(TimeFormat), TimeSpan = dateTime.TimeOfDay, Id = (int)dateTime.TimeOfDay.TotalMinutes });

            if (timeIncrement == TimeIncrement.Quarterly)
            {
                hoursList.Add(new HourItem() { Text = dateTime.AddMinutes(15).ToString(TimeFormat), TimeSpan = dateTime.AddMinutes(15).TimeOfDay, Id = (int)dateTime.AddMinutes(15).TimeOfDay.TotalMinutes });
                hoursList.Add(new HourItem() { Text = dateTime.AddMinutes(30).ToString(TimeFormat), TimeSpan = dateTime.AddMinutes(30).TimeOfDay, Id = (int)dateTime.AddMinutes(30).TimeOfDay.TotalMinutes });
                hoursList.Add(new HourItem() { Text = dateTime.AddMinutes(45).ToString(TimeFormat), TimeSpan = dateTime.AddMinutes(45).TimeOfDay, Id = (int)dateTime.AddMinutes(45).TimeOfDay.TotalMinutes });
            }
            else if (timeIncrement == TimeIncrement.HalfHour)
            {
                hoursList.Add(new HourItem() { Text = dateTime.AddMinutes(30).ToString(TimeFormat), TimeSpan = dateTime.AddMinutes(30).TimeOfDay, Id = (int)dateTime.AddMinutes(30).TimeOfDay.TotalMinutes });
            }
        }

        return hoursList;

    }
}