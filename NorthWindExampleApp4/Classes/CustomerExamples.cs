using EntityFrameworkLibrary;
using EntityFrameworkLibrary.Models;
using Microsoft.EntityFrameworkCore;
using NorthWindExampleApp4.Data;
using NorthWindExampleApp4.Models;

namespace NorthWindExampleApp4.Classes;
internal class CustomerExamples
{


    //public static async Task<List<Customers>> OrderByOnNavigation1(string ordering, OrderingDirection direction)
    //{
    //    await using var context = new Context();

    //    if (direction == OrderingDirection.Ascending)
    //    {
    //        return await context.Customers
    //            .Include(c => c.CountryIdentifierNavigation)
    //            .Include(c => c.Contact)
    //            .Include(c => c.ContactTypeIdentifierNavigation)
    //            .OrderByColumn(ordering)
    //            .ToListAsync();
    //    }
    //    else
    //    {
    //        return await context.Customers
    //            .Include(c => c.CountryIdentifierNavigation)
    //            .Include(c => c.Contact)
    //            .Include(c => c.ContactTypeIdentifierNavigation)
    //            .OrderByColumnDescending(ordering)
    //            .ToListAsync();
    //    }

    //}

}
