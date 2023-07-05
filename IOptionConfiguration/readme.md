# About

Basic example for application configuration.

## appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Your connection string"
  },
  "AppSettings": {
    "Name": "Karen Payne",
    "DefaultConnection": "Your connection string"
  }
}
```

## Model

```csharp
public class ApplicationSettingsOptions
{
    // section in appsettings.json
    public const string Settings = "AppSettings";
    public string Name { get; set; } = string.Empty;
    public string DefaultConnection { get; set; } = string.Empty;
}
```

## Program.cs

```csharp
builder.Services.AddRazorPages();

builder.Services.Configure<ApplicationSettingsOptions>(
    builder.Configuration.GetSection(ApplicationSettingsOptions.Settings));
```

## Usage in Index page

```csharp
public class IndexModel : PageModel
{
    
    private readonly ApplicationSettingsOptions _options;
    [BindProperty]
    public string ConnectionString { get; set; }
    public IndexModel(IOptions<ApplicationSettingsOptions> options)
    {
        _options = options.Value;
        ConnectionString = _options.DefaultConnection;

        Log.Information("Name {N1}", _options.Name);
    }

    public void OnGet()
    {

    }
}
```
