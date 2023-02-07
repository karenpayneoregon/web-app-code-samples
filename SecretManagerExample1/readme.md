# About

- In a terminal window, in the root folder of the project `dotnet user-secrets init` which adds an entry to the project file
- Add a section in `appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "googleMapApi": {
    "apiKey": "Enter anything here",
    "apiUrl": "https://maps.googleapis.com/maps/api/json?"
  }
}
```

- Back in the terminal window `dotnet user-secrets set "googleMapApi:apiKey" "KP12345"`
- Read the secret

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecretManagerExample1.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public string SecretKey { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void OnGet()
    {
        var key = _config["googleMapApi:apiKey"];
        _logger.LogInformation(key);
        SecretKey = key;
    }
}
```

- Display the key

```html
<wrapper class="d-flex flex-column min-vh-100">

    <main class="flex-fill d-flex align-items-center">
        <div class="container-fluid text-center">API Key <span class="text-info fw-bold">@Model.SecretKey</span> </div>
    </main>

</wrapper>
```

**Microsoft docs**

- [Safe storage of app secrets in development in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows)
- [Manage user secrets with Visual Studio](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows#manage-user-secrets-with-visual-studio)

**Secrets folder**

C:\Users\\`CurrentUser`\AppData\Roaming\Microsoft\UserSecrets\\`user_secrets_id`\secrets.json

# List secrets

From a terminal window

```
dotnet user-secrets list
```