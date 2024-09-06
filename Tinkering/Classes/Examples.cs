using System;
using System.Collections.Generic;
using System.Linq;
using Tinkering.Models;

namespace Tinkering.Classes;

internal class Examples
{
    public static void ReorderDemo()
    {
        var list = Categories;
        list = list.OrderBy(c => Identities.IndexOf(c.CategoryId)).ToList();
        list.ForEach(cat => Console.WriteLine(cat.CategoryName));
    }
    public static List<int> Identities => Enumerable.Range(-1, 12).ToList();
    public static List<Categories> Categories =
    [
        new() { CategoryId = 1, CategoryName = "Beverages" },
        new() { CategoryId = 2, CategoryName = "Condiments" },
        new() { CategoryId = 3, CategoryName = "Confections" },
        new() { CategoryId = 4, CategoryName = "Dairy Products" },
        new() { CategoryId = 5, CategoryName = "Grains/Cereals" },
        new() { CategoryId = 6, CategoryName = "Meat/Poultry" },
        new() { CategoryId = 7, CategoryName = "Produce" },
        new() { CategoryId = 8, CategoryName = "Seafood" },
        new() { CategoryId = -1, CategoryName = "Select" },
        new() { CategoryId = 9, CategoryName = "Wine" }
    ];
}



