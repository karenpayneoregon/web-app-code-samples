﻿# Application configuration providers

An example for reading settings from appsettings.json.

- Index page is not dependency injection
- Example page uses dependency injection

```csharp
builder.Services.Configure<Contact>(
    builder.Configuration.GetSection(Contact.Location));
```

Example page code behind

```csharp
public class ExampleModel : PageModel
{
    public Contact Contact;

    public ExampleModel(IOptions<Contact> options)
    {
        Contact = options.Value;
    }
    public void OnGet()
    {
        var test = Contact.FirstName;
    }
}
```

appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Contact": {
    "FirstName": "Karen",
    "LastName": "Payne",
    "EmailAddress": "kp@comcast.com",
    "Region": "USA"
  }
}
```




## Microsoft docs

Application configuration in ASP.NET Core is performed using one or more [configuration providers](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?source=recommendations&view=aspnetcore-7.0#cp). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

- Settings files, such as appsettings.json
- Environment variables
- Azure Key Vault
- Azure App Configuration
- Command-line arguments
- Custom providers, installed or created
- Directory files
- In-memory .NET objects

[Read more](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?source=recommendations&view=aspnetcore-7.0)