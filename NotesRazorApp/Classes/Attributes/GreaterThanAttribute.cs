using System.ComponentModel.DataAnnotations;

namespace NotesRazorApp.Classes.Attributes;

/// <summary>
/// Provides rule to ensure property value is not less than <see cref="Minimum"/>
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class GreaterThanAttribute : ValidationAttribute
{
    /// <summary>
    /// Assert a value is greater than <see cref="Minimum"/>
    /// </summary>
    /// <param name="minimum">value to validate</param>
    public GreaterThanAttribute(string minimum)
    {
        Minimum = Convert.ToDateTime(minimum);
    }
    public DateTime Minimum { get; set; }
    public override string FormatErrorMessage(string name)
    {
        if (ErrorMessage is null && ErrorMessageResourceName is null)
        {
            ErrorMessage = "is unacceptable";
        }

        return $"{name} must be greater than {Minimum.ToShortDateString()}";

    }

    public override bool IsValid(object? sender)
    {
        if (sender is { })
        {
            return sender is DateTime value && value > Minimum;
        }

        return false;
    }
}