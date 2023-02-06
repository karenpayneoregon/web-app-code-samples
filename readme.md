# Razor pages code samples

# TempDatav code sample

ASP.NET Core exposes the Razor Pages TempData or Controller [TempData](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#tempdata-1). This property stores data until it's read in another request. The [Keep](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.itempdatadictionary.keep?view=aspnetcore-7.0)(String) and [Peek](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.itempdatadictionary.peek?view=aspnetcore-7.0)(string) methods can be used to examine the data without deletion at the end of the request. Keep marks all items in the dictionary for retention. TempData is:

- Useful for redirection when data is required for more than a single request.
- Implemented by `TempData` providers using either cookies or session state.

In the project `WorkingWithTempData` we will show how to use `TempData` for complex types, string and numbers.

| Project        |   Description    |
|:------------- |:-------------|
| Custom404Page | Simple example for a custom 404 page |
| RazorPagesAJAXNamedHandlersDemo | Using Named Handler Methods to Make jQuery AJAX GET Calls in Razor Pages |  
| RazorLibrary | For helper classes |  
| Revenue.Configuration.Core1 | Example for storing application settings in a SQL-Server database  |  
| RevenueFrontEnd | Frontend for Revenue.Configuration.Core1 |  
| SeriLogLibrary | Helpers for SeriLog |  
| IsolationWebApp | Example for Razor Pages css isolation (most samples are for Blazor) |  
| EnvironmentApplication | Example for conditionally displaying user inferface elements |  
| MultipleSubmitButtons1 | Shows how to have multiple submit buttons for a form. |  
| MultipleSubmitButtons2 | Demo for SeriLog coloring output using code from SeriLogLibrary |  
| MockupApplication | Basic example for working with [IDataProtector](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.dataprotection.idataprotector?view=aspnetcore-7.0) along with a simple login page. |  
| SerilogCustomLogColors | SeriLog |  
| WorkingWithTempData | Example for working with TemData |  
| SessionStateBasic | Basic example for session states |  