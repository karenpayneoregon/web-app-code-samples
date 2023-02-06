# TempData code sample

ASP.NET Core exposes the Razor Pages TempData or Controller [TempData](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-3.1#tempdata-1). This property stores data until it's read in another request. The [Keep](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.itempdatadictionary.keep?view=aspnetcore-7.0)(String) and [Peek](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.itempdatadictionary.peek?view=aspnetcore-7.0)(string) methods can be used to examine the data without deletion at the end of the request. Keep marks all items in the dictionary for retention. TempData is:

- Useful for redirection when data is required for more than a single request.
- Implemented by `TempData` providers using either cookies or session state.

In the project `WorkingWithTempData` we will show how to use `TempData` for complex types, string and numbers.
