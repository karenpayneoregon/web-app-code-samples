using System.Data;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn()
        {
            ColumnName = "Id",
            DataType = typeof(int),
            AutoIncrement = true,
            AutoIncrementSeed = 1,
            ColumnMapping = MappingType.Hidden
        });
        dt.Columns.Add(new DataColumn() { ColumnName = "Name", DataType = typeof(string) });
        dt.Columns.Add(new DataColumn() { ColumnName = "DOB", DataType = typeof(DateTime) });


        dt.Rows.Add(null, "Jim Kirk", new DateTime(1945,12,3));
        dt.Rows.Add(null, "Mr. Spock", new DateTime(1948,9,6));

        var treckies = dt.DataTableToList<Person>();

        foreach (var person in treckies)
        {
            Console.WriteLine($"{person.Id,-4}{person.Name,-20}{person.DOB:d}");
        }
        Console.ReadLine();
    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DOB { get; set; }
}
public static class Extensions
{
    public static List<TSource> DataTableToList<TSource>(this DataTable table) where TSource : new()
    {
        List<TSource> list = new();

        var typeProperties = typeof(TSource).GetProperties().Select(propertyInfo => new
        {
            PropertyInfo = propertyInfo,
            Type = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType
        }).ToList();

        foreach (var row in table.Rows.Cast<DataRow>())
        {

            TSource current = new();

            foreach (var typeProperty in typeProperties)
            {
                object value = row[typeProperty.PropertyInfo.Name];
                object safeValue = value is null || DBNull.Value.Equals(value) ?
                    null :
                    Convert.ChangeType(value, typeProperty.Type!);

                typeProperty.PropertyInfo.SetValue(current, safeValue, null);
            }

            list.Add(current);

        }

        return list;
    }
}