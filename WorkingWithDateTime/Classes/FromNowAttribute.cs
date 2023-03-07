using System.ComponentModel.DataAnnotations;

namespace WorkingWithDateTime.Classes;

public class FromNowAttribute : ValidationAttribute
{
    public FromNowAttribute() { }

    public string GetErrorMessage() => "Date can not be in a future year";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var date = (DateTime)value;

        if (DateTime.Compare(date, DateTime.Now) < 0)
        {
            return new ValidationResult(GetErrorMessage());
        }
        else
        {
            return ValidationResult.Success;
        }
    }
}