#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace HoursApplication.Models;

public class HourItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public TimeSpan? TimeSpan { get; set; }
    public override string ToString() => Text;
}