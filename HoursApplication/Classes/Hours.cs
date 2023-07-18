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

    public static string TimeFormat { get; set; } = "hh:mm tt";

    public static List<HourItem> Range(TimeIncrement pTimeIncrement = TimeIncrement.Hourly)
    {

        IEnumerable<DateTime> hours = Enumerable.Range(0, 24)
            .Select((index) => (DateTime.MinValue.AddHours(index)));

        var timeList = new List<HourItem> { new() {Text ="Select", Id = -1, TimeSpan = null} };
        foreach (var dateTime in hours)
        {

            timeList.Add(new HourItem()
            {
                Text = dateTime.ToString(TimeFormat), 
                TimeSpan = dateTime.TimeOfDay,
                Id = (int)dateTime.TimeOfDay.TotalMinutes
            });

            if (pTimeIncrement == TimeIncrement.Quarterly)
            {
                timeList.Add(new HourItem()
                {
                    Text = dateTime.AddMinutes(15).ToString(TimeFormat),
                    TimeSpan = dateTime.AddMinutes(15).TimeOfDay,
                    Id = (int)dateTime.AddMinutes(15).TimeOfDay.TotalMinutes
                });

                timeList.Add(new HourItem()
                {
                    Text = dateTime.AddMinutes(30).ToString(TimeFormat),
                    TimeSpan = dateTime.AddMinutes(30).TimeOfDay,
                    Id = (int)dateTime.AddMinutes(30).TimeOfDay.TotalMinutes
                });
                
                timeList.Add(new HourItem()
                {
                    Text = dateTime.AddMinutes(45).ToString(TimeFormat),
                    TimeSpan = dateTime.AddMinutes(45).TimeOfDay,
                    Id = (int)dateTime.AddMinutes(45).TimeOfDay.TotalMinutes
                });
            }
            else if (pTimeIncrement == TimeIncrement.HalfHour)
            {
                timeList.Add(new HourItem()
                {
                    Text = dateTime.AddMinutes(30).ToString(TimeFormat), 
                    TimeSpan = dateTime.AddMinutes(30).TimeOfDay,
                    Id = (int)dateTime.AddMinutes(30).TimeOfDay.TotalMinutes
                });
            }
        }

        return timeList;

    }
}

public class HourItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public TimeSpan? TimeSpan { get; set; }
    public override string ToString() => Text;

}

public enum TimeIncrement
{
    Hourly,
    Quarterly,
    HalfHour
}