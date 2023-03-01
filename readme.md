# Razor pages code samples

A collection of basic to advance code samples.

| Project        |   Description    |
|:------------- |:-------------|
| Bootstrap5OffCanvasExample | Simple example for `offcanvas` |
| Configuration1 | Shows how to read custon values from appsettings.json |
| Configuration2 | Shows how to read custon values from appsettings.json access in a page |
| CheckedListBox | Has two samples for checked listbox, Index page works but not recommended while Index1 page is the correct way w/o a controller |
| Custom404Page | Simple example for a custom 404 page |
| ConditionalLayout | Shows how to change the layout file condionally on is week day or weekend |
| DropdownForCountries | Shows how to populate a dropdown using EF Core 7 |
| DropdownEumRazorPages | Demonstrates loading a dropdown for enum |
| EnvironmentApplication | Example for conditionally displaying user inferface elements |  
| IsolationWebApp | Example for Razor Pages css isolation (most samples are for Blazor) |  
| LeftSideNavigation | Navigation on left side of page |
| MultipleSubmitButtons1 | Shows how to have multiple submit buttons for a form. |  
| MultipleSubmitButtons2 | Demo for SeriLog coloring output using code from SeriLogLibrary |  
| MockupApplication | Basic example for working with [IDataProtector](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.dataprotection.idataprotector?view=aspnetcore-7.0) along with a simple login page. |  
| RadioButtonsExample | Working with radio buttons with a strong typed list. Has several examples |
| RazorPagesAJAXNamedHandlersDemo | Using Named Handler Methods to Make jQuery AJAX GET Calls in Razor Pages |  
| RazorLibrary | For helper classes |  
| | TempData helpers|
| | Method to bring console window to front when starting a web app from Visual Studio |
| Revenue.Configuration.Core1 | Example for storing application settings in a SQL-Server database  |  
| RevenueFrontEnd | Frontend for Revenue.Configuration.Core1 |  
| SecretManagerExample1 | Basic example for storing secrets in an app |
| SeriLogLibrary | Helpers for SeriLog |  
| SerilogCustomLogColors | SeriLog |  
| SeriLogConditional | Toggle SeriLog within a razor page |
| SessionStateBasic | Basic example for session states |  
| SimpleModelBinding | Shows form binding w/o a data source |
| WorkingWithTempData | Example for working with TemData |  
| DependencyInjectionBasic | Basics for DI |

## Why Razor Pages?

### Straightforward structure

ASP.NET Core Razor Pages takes a page-focused approach to the project structure. It colocates a page’s view and its PageModel (logic pertaining to a view) in a `Pages` directory. If you’ve modeled your content and identified that the majority of it is structured around the concept of a `page`, then Razor Pages may be the perfect framework for your project.