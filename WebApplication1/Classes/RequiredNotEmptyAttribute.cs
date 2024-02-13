using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Classes;

public class RequiredNotEmptyAttribute : RequiredAttribute
{
    public override bool IsValid(object value)
    {
        if (value is string s) return !string.IsNullOrEmpty(s);

        return base.IsValid(value);
    }
}