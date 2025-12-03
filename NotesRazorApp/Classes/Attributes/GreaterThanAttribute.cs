using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8632

namespace NotesRazorApp.Classes.Attributes;

/// <summary>
/// Specifies a validation attribute that checks if the value of a property or field 
/// is greater than a specified minimum value.
/// </summary>
/// <remarks>
/// This attribute is typically used to validate that a <see cref="DateTime"/> value 
/// is greater than the defined <see cref="Minimum"/> value. It is applied to properties 
/// or fields and ensures that the validation logic is enforced.
/// </remarks>
/// <example>
/// The following example demonstrates how to use the <see cref="GreaterThanAttribute"/>:
/// <code>
/// [GreaterThan("11/1/2022")]
/// public DateTime? DueDate { get; set; }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class GreaterThanAttribute : ValidationAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GreaterThanAttribute"/> class 
    /// with the specified minimum value.
    /// </summary>
    /// <param name="minimum">
    /// The minimum value as a string that the property or field must be greater than. 
    /// This value is converted to a <see cref="DateTime"/>.
    /// </param>
    /// <exception cref="FormatException">
    /// Thrown if the <paramref name="minimum"/> cannot be converted to a valid <see cref="DateTime"/>.
    /// </exception>
    /// <remarks>
    /// This constructor is used to define the minimum value for validation. The value 
    /// provided is parsed into a <see cref="DateTime"/> and used in the validation logic.
    /// </remarks>
    public GreaterThanAttribute(string minimum)
    {
        Minimum = Convert.ToDateTime(minimum);
    }
    public DateTime Minimum { get; set; }
    
    /// <summary>
    /// Formats the error message to display when validation fails.
    /// </summary>
    /// <param name="name">
    /// The name of the property or field being validated.
    /// </param>
    /// <returns>
    /// A formatted error message indicating that the value of the property or field 
    /// must be greater than the specified <see cref="Minimum"/> value.
    /// </returns>
    /// <remarks>
    /// This method overrides the base implementation to provide a custom error message 
    /// that includes the name of the property or field and the minimum value.
    /// </remarks>
    public override string FormatErrorMessage(string name)
    {
        if (ErrorMessage is null && ErrorMessageResourceName is null)
        {
            ErrorMessage = "is unacceptable";
        }

        return $"{name} must be greater than {Minimum.ToShortDateString()}";

    }


    /// <summary>
    /// Validates that the value of the property or field is greater than the specified <see cref="Minimum"/> value.
    /// </summary>
    public override bool IsValid(object? sender) 
        => sender is DateTime value && value > Minimum;
}