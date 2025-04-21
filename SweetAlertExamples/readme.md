# About

Shows how to use several dialogs from [limonte-sweetalert2](https://sweetalert2.github.io)

![Screenshots](assets/screenshots.png)

## Index page MessageBox

To get on confirm for the message box to work, alter Program.cs to the following:
```csharp
builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new AutoValidateAntiforgeryTokenAttribute());
});
```

Then, in the Index.cshtml.cs file, add the following code:

```csharp
[IgnoreAntiforgeryToken] // <<< THIS is critical
public class IndexModel : PageModel
```

Followed by the following code which is invoke via JavaScript:
```csharp
public IActionResult OnPostSwalConfirmed()
{
    Console.WriteLine($"Invoked from the MessageBox in {nameof(IndexModel).Replace("Model","")}");
    return new JsonResult(new { success = true });
}
```