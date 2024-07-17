#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace NewPasswordExample.Rules;
public class NotEqualTo : ValidationAttribute
{
    private readonly string _other;
    public NotEqualTo(string other)
    {
        _other = other;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherProperty = validationContext.ObjectType.GetProperty(_other);
        if (otherProperty == null)
        {
            return new ValidationResult($"Property {_other} not found");
        }

        var otherValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

        if (Equals(value, otherValue))
        {
            string otherName = otherProperty.GetCustomAttribute(
                typeof(DisplayAttribute)) is DisplayAttribute otherDisplayAttribute ? 
                otherDisplayAttribute.Name : 
                otherProperty.Name;

            ErrorMessage = $"{validationContext.DisplayName} cannot be the same as {otherName}";

            return new ValidationResult(this.ErrorMessage);
        }

        return null;
    }
}
