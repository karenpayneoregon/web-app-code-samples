using System.ComponentModel.DataAnnotations;

namespace DropdownEumRazorPages.Classes;

public sealed class InvalidEnumsAttribute : ValidationAttribute
{

    private List<object> _invalidValues = new List<object>();



    public InvalidEnumsAttribute(Type enumType, params object[] enumValues)
    {
        foreach (var enumValue in enumValues)
        {
            var _invalidValueParsed = Enum.Parse(enumType, enumValue.ToString());
            _invalidValues.Add(_invalidValueParsed);
        }
    }

    public override bool IsValid(object value)
    {
        foreach (var invalidValue in _invalidValues)
        {
            if (Enum.Equals(invalidValue, value))
                return false;
        }
        return true;
    }

}