using System.Data;
using System.Reflection;

namespace Tinkering.Classes;
public static class GenericExtensions
{
    public static DataTable ToDataTable<T>(this List<T> list, string tableName)
    {
        DataTable dt = new(tableName);

        foreach (PropertyInfo info in typeof(T).GetProperties())
        {
            dt.Columns.Add(new DataColumn(info.Name, 
                Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
        }
        foreach (T item in list)
        {
            DataRow row = dt.NewRow();
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                row[info.Name] = info.GetValue(item, null) ?? DBNull.Value;
            }
            dt.Rows.Add(row);
        }

        return dt;
    }
}
