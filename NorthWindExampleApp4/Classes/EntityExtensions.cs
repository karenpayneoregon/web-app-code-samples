using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NorthWindExampleApp4.Data;
using NorthWindExampleApp4.Models;

#pragma warning disable CS8603

namespace NorthWindExampleApp4.Classes;

public static class EntityExtensions
{




    /// <summary>
    /// Get details for a model
    /// </summary>
    /// <param name="context">Active dbContext</param>
    /// <param name="modelName">Model name in context</param>
    /// <returns>List&lt;SqlColumn&gt;</returns>
    /// <remarks>
    /// More information can be added as needed
    /// </remarks>
    public static List<SqlColumn> GetModelProperties(this DbContext context, string modelName)
    {

        if (context == null) throw new ArgumentNullException(nameof(context));

        var entityType = GetEntityType(context, modelName);

        var list = new List<SqlColumn>();

        IEnumerable<IProperty> properties = context.Model
            .FindEntityType(entityType ?? throw new InvalidOperationException())!
            .GetProperties();

        int id = 1;
        foreach (IProperty itemProperty in properties)
        {
            SqlColumn sqlColumn = new()
            {
                Id = id++,
                Name = itemProperty.Name,
                IsPrimaryKey = itemProperty.IsKey(),
                IsForeignKey = itemProperty.IsForeignKey(),
                IsNullable = itemProperty.IsColumnNullable(),
                Type = itemProperty.PropertyInfo!.PropertyType
            };


            list.Add(sqlColumn);

        }

        return list;

    }
    private static Type GetEntityType(DbContext context, string modelName) =>
        context.Model.GetEntityTypes()
            .Select(eType => eType.ClrType)
            .FirstOrDefault(type => type.Name == modelName);
}