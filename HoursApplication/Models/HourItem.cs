namespace HoursApplication.Models;

public class HourItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public TimeSpan? TimeSpan { get; set; }
    public override string ToString() => Text;
}