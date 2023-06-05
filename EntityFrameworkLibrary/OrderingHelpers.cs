using System.Linq.Expressions;
using EntityFrameworkLibrary.Models;

namespace EntityFrameworkLibrary;
public static class OrderingHelpers
{
    /// <summary>
    /// Generic top level order by property name
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <param name="list">List of <see cref="T"/></param>
    /// <param name="propertyName">Column/property to order or</param>
    /// <param name="sortDirection">Direction of ordering</param>
    /// <remarks>
    /// Intended to be used with methods in EntityExtensions class
    /// </remarks>
    public static List<T> OrderByPropertyName<T>(this List<T> list, string propertyName, OrderingDirection sortDirection = OrderingDirection.Ascending)
    {

        ParameterExpression param = Expression.Parameter(typeof(T), "item");

        Expression<Func<T, object>> sortExpression = Expression.Lambda<Func<T, object>>(
                Expression.Convert(Expression.Property(param, propertyName), typeof(object)),
                param);

        list = sortDirection switch
        {
            OrderingDirection.Ascending => list.AsQueryable().OrderBy(sortExpression).ToList(),
            _ => list.AsQueryable().OrderByDescending(sortExpression)
                .ToList()
        };

        return list;

    }


}
