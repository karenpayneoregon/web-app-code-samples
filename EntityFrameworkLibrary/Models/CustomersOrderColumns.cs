namespace EntityFrameworkLibrary.Models;

/// <summary>
/// Pre-defined columns for Customers model order by
/// </summary>
public class CustomersOrderColumns
{
    public static List<OrderColumn> List() =>
        new()
        {
            new() { PropertyName = CustomerPropertyName.FirstName, Column = "Contact.FirstName" },
            new() { PropertyName = CustomerPropertyName.LastName, Column = "Contact.LastName" },
            new() { PropertyName = CustomerPropertyName.Title, Column = "ContactTypeIdentifierNavigation.ContactTitle" },
            new() { PropertyName = CustomerPropertyName.CountryName, Column = "CountryIdentifierNavigation.Name" }
        };
}