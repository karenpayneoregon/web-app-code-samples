using System.ComponentModel.DataAnnotations;

namespace WorkingWithDateTime.Classes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class YearRangeAttribute : RangeAttribute
{
    /// <summary>
    /// Range between <param name="minimum"></param> and current year
    /// </summary>
    /// <param name="minimum">Minimum date</param>
    public YearRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
    {
    }
}