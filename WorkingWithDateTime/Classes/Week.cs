using System.ComponentModel;
using System.Globalization;

namespace WorkingWithDateTime.Classes;


[TypeConverter(typeof(WeekConverter))]
public class Week
{
    public int Year { get; set; }
    public int WeekNumber { get; set; }

    public static Week TryParse(string input)
    {
        var result = input.Split("-W");
        
        if (result.Length != 2)
        {
            return null;
        }
        if (int.TryParse(result[0], out int year) && int.TryParse(result[1], out int week))
        {
            return new Week { Year = year, WeekNumber = week };
        }

        return null;
    }

    public override string ToString()
    {
        return $"{Year}-W{WeekNumber:D2}";
    }
}
public class WeekConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
        return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
    }

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string input)
        {
            return Week.TryParse(input);
        }

        return base.ConvertFrom(context, culture, value);
    }
}