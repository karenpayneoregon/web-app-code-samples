# Add Select option to a Dropdown


This code sample demonstrates how to add a select option to a dropdown/select element using EF Core and a data provider using SQL-Server NorthWind database using category and contact type tables.

For each select, data is read from a database table as follows were the DECLARE is replaced for the data provider Microsoft.Data.SqlClient with a parameter and with EF Core inserted to a list as the first item.

Note the parameter below **@SelectText**

```sql
DECLARE @SelectText AS NVARCHAR(50) = N'Select';

SELECT -1 AS CategoryID,
       @SelectText AS CategoryName
UNION ALL
SELECT CategoryID,
       CategoryName
FROM dbo.Categories
ORDER BY CategoryName;

SELECT -1 AS ContactTypeIdentifier,
       @SelectText AS ContactTitle
UNION ALL
SELECT ContactTypeIdentifier,
       ContactTitle
FROM dbo.ContactType
ORDER BY ContactTitle;
```

Then for the data provider after data is read into a list the following provides a custom order by which starts with **-1** which represents the item to have a user make a selection.

```csharp
var identities = Enumerable.Range(-1, count).ToList();
```

Data is read then ordered using the above list.

```csharp
list.OrderBy(c => identities.IndexOf(c.CategoryID)).ToList();
```



## Select text

The select text is stored in appsettings.json, in this case one for each page.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore.Database.Command": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ApplicationFeatures": {

    "IndexPage": {
      "SelectText": "Select"
    },
    "Index1Page": {
      "SelectText": "Select"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.\\SQLEXPRESS;Initial Catalog=Northwind2020;Integrated Security=True;Encrypt=False"
  }
}
```

### Model for above

```csharp
public class ApplicationFeatures
{
    /// <summary>
    /// Index page section in appsettings.json
    /// </summary>
    public const string Index = "ApplicationFeatures:IndexPage";
    /// <summary>
    /// Index1 page section in appsettings.json
    /// </summary>
    public const string Index1 = "ApplicationFeatures:Index1Page";
    public string SelectText { get; set; }
}
```

- Two constants point to sections in appsettings.json
- SelectText property points to text used for the first item in each dropdown.

## Index page

This page uses EF Core for populating the select element.

1. In the page constructor gets the selection text from appsettings
1. Reads data from the Categories table with an order by on CategoryName
1. Inserts select text into the list
1. Creates a List&lt;SelectListItem> for the list
1. Then in the frontend create the select element set to the SelectListItem and name set to the primary key, in this case CategoryID which on post will have the selected item.

```html
<label asp-for="SelectedCategory">
    Categories
    <select name="CategoryID"
            asp-for="SelectedCategory"
            class="form-select"
            style="width: 9.2em"
            asp-items="Model.Options">
    </select>
</label>
```

## Index1 page


This page uses the data provider for populating the select element.

1. In the page constructor gets the selection text from appsettings
1. Reads data from the Categories table with an order by on CategoryName and add the select option from the class **ReferenceTableOperations**
1. Inserts select text into the list
1. Creates a List&lt;SelectListItem> for the list
1. Then in the frontend create the select element set to the SelectListItem and name set to the primary key, in this case CategoryID which on post will have the selected item.

```html
<label asp-for="SelectedCategory">
   Categories
   <select name="CategoryID"
      asp-for="SelectedCategory"
      class="form-select"
      style="width: 9.2em"
      asp-items="Model.Options">
   </select>
</label>
```

## Both pages select element

Although both pages load the data differently, they both use the same HTML configuration.

## Ordering for data provider



