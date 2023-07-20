using HoursApplication.Classes;

namespace HoursApplication.Models;

/// <summary>
/// For use with <seealso cref="Hours"/> which determines time increment
/// </summary>
public enum TimeIncrement
{
    Hourly,
    Quarterly,
    HalfHour
}