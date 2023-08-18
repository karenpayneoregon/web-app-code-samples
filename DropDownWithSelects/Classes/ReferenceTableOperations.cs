using System.Data;
using DropDownWithSelects.Models;
using Microsoft.Data.SqlClient;

namespace DropDownWithSelects.Classes;

/// <summary>
/// Methods for interacting with NorthWind database tables
/// </summary>
public class ReferenceTableOperations
{

    public static string? ConnectionString
        => ConfigurationRoot()
            .GetConnectionString("DefaultConnection");

    public static IConfigurationRoot ConfigurationRoot() =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

    /// <summary>
    /// Create a sorted list of <see cref="Categories"/> with a select
    /// option at top of list.
    /// </summary>
    public static List<Categories> ReadCategoriesForDropDown(int count, string selectionText = "Options")
    {
        List<Categories> list = new();

        List<int> identities = Enumerable.Range(-1, count).ToList();

        using SqlConnection cn = new() { ConnectionString = ConnectionString };
        var selectStatement =
            """
            SELECT -1 AS CategoryID,
                   @SelectText AS CategoryName
            UNION ALL
            SELECT CategoryID,
                   CategoryName
            FROM dbo.Categories
            ORDER BY CategoryName;
            """;
        using SqlCommand cmd = new() { Connection = cn, CommandText = selectStatement };
        cmd.Parameters.Add("@SelectText", SqlDbType.NVarChar).Value = selectionText;
        cn.Open();
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Categories() { CategoryID = reader.GetInt32(0), CategoryName = reader.GetString(1) });
        }

        return list.OrderBy(c => identities.IndexOf(c.CategoryID)).ToList();

    }

    /// <summary>
    /// Create a sorted list of <see cref="ContactType"/> with a select
    /// option at top of list.
    /// </summary>
    public static List<ContactType> ReadContactTypesForDropDown(int count)
    {
        var list = new List<ContactType>();

        var identities = Enumerable.Range(-1, count).ToList();

        using SqlConnection cn = new() { ConnectionString = ConnectionString };
        var selectStatement =
            """
            SELECT -1 AS ContactTypeIdentifier,
                   'Select' AS ContactTitle
            UNION ALL
            SELECT ContactTypeIdentifier,
                   ContactTitle
            FROM dbo.ContactType
            ORDER BY ContactTitle;
            """;
        using SqlCommand cmd = new() { Connection = cn, CommandText = selectStatement };

        cn.Open();
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new ContactType() { ContactTypeIdentifier = reader.GetInt32(0), ContactTitle = reader.GetString(1) });
        }

        return list.OrderBy(c => identities.IndexOf(c.ContactTypeIdentifier)).ToList();

    }
    /// <summary>
    /// Table counts for select operations
    /// </summary>
    public static (int category, int contactType) GetTableCount()
    {
        using SqlConnection cn = new() { ConnectionString = ConnectionString };
        var selectStatement =
            """
            SELECT COUNT(c.CategoryID) FROM dbo.Categories AS c;
            SELECT COUNT(ct.ContactTypeIdentifier) FROM dbo.ContactType AS ct;
            """;

        using SqlCommand cmd = new() { Connection = cn, CommandText = selectStatement };

        cn.Open();

        using var reader = cmd.ExecuteReader();

        reader.Read();
        var categoryCount = reader.GetInt32(0);

        reader.NextResult();

        reader.Read();
        var contactTypeCount = reader.GetInt32(0);

        return (categoryCount + 2, contactTypeCount + 2);

    }

    /// <summary>
    /// Get category name by primary key
    /// </summary>
    /// <param name="id">existing key</param>
    public static string GetCategoryName(int id)
    {
        using SqlConnection cn = new() { ConnectionString = ConnectionString };
        var selectStatement =
            """
            SELECT c.CategoryName FROM dbo.Categories AS c WHERE c.CategoryID = @Id
            """;

        using SqlCommand cmd = new() { Connection = cn, CommandText = selectStatement };
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

        cn.Open();
        using var reader = cmd.ExecuteReader();
        reader.Read();
        return reader.GetString(0);
    }
}
