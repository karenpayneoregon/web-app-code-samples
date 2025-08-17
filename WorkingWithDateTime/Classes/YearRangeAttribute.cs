using System.ComponentModel.DataAnnotations;

namespace WorkingWithDateTime.Classes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class YearRangeAttribute : RangeAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="YearRangeAttribute"/> class with a specified minimum year.
    /// </summary>
    /// <param name="minimum">The minimum year allowed in the range.</param>
    /// <remarks>
    /// The maximum year is automatically set to the current year.
    /// </remarks>
    public YearRangeAttribute(int minimum) : base(minimum, DateTime.Now.Year)
    {
    }
}