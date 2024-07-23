# About


User secrets in console project.

Safe storage of [app secrets in development](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows) in ASP.NET Core

## NuGet packages

Install-Package Microsoft.Extensions.Configuration

Install-Package Microsoft.Extensions.Hosting

Install-Package Microsoft.Extensions.Configuration.UserSecrets

## Class to read secrets

```csharp
public class SecretAppSettingReader
{
    public T ReadSection<T>(string sectionName)
    {
        var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        return configurationRoot.GetSection(sectionName).Get<T>();
    }
}
```

## Steps to working with secrets

1. Create a new Console project.
1. Open a terminal window at the root of the project.
1. Run `dotnet user-secrets init` which places an entry into the project file.

```xml
<PropertyGroup>
   <TargetFramework>net7.0</TargetFramework>
   <UserSecretsId>1fe850fa-6fb3-4320-8003-b70d16d1a649</UserSecretsId>
</PropertyGroup>
```

4.  From here, decide what you want to store as secrets. For this article we want to store a database connection string and settings to send email messages.


The **appsettings.json**

```json
{  
  "ConnectionStrings": {
    "DefaultConnection": "Enter anything here"
  },
  "MailSettings": {
    "FromAddress": "",
    "Host": "",
    "Port": 0,
    "TimeOut": 0,
    "PickupFolder": ""
  }
}
```

5. Create a class to read MailSettings from appsettings.json

```csharp
public class MailSettings
{
    public string FromAddress { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public int TimeOut { get; set; }
    public string PickupFolder { get; set; } = "MailDrop";
}
```

For the connection string we do not need a class.

**Storing data for the secrets manager**

Create a folder named DotnetSecrets off the root of C to store a json file outside of the Visual Studio solution. Keeping this simple, lets call it secrets.json and add the following.

```json
{
  "ConnectionStrings:DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF.NotesDatabase;Integrated Security=True",
  "MailSettings": {
    "FromAddress": "FromAddress",
    "Host": "SomeHost",
    "Port": 25,
    "TimeOut": 3000,
    "PickupFolder": "MailDrop"
  }
}
```

To add the settings above, in a terminal window execute the following.

```
type C:\DotnetSecrets\secrets.json | dotnet user-secrets set --project "C:\VS2022\LanguageFeatures\SecretManager1\SecretManager1.csproj"
```

> **Note**
> Alter the path and project name for --project above for when doing this for your project.

**Validation**

Right click on your project, select Manage user secrets which opens secrets.json for this project and will appear as follows.



```json
{
  "ConnectionStrings:DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EF.NotesDatabase;Integrated Security=True",
  "MailSettings:FromAddress": "FromAddress",
  "MailSettings:Host": "SomeHost",
  "MailSettings:Port": "25",
  "MailSettings:TimeOut": "3000",
  "MailSettings:PickupFolder": "MailDrop"
}
```

Or from the terminal at the project root 


```
dotnet user-secrets list
```

In this case we get

```
MailSettings:TimeOut = 3000
MailSettings:Port = 25
MailSettings:PickupFolder = MailDrop
MailSettings:Host = SomeHost
MailSettings:FromAddress = FromAddress
ConnectionStrings:DefaultConnection = Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EF.NotesDatabase;Integrated Security=True
```

## Sample code to read secrets

```csharp
internal partial class Program
{
    static void Main(string[] args)
    {
        var reader = new SecretAppSettingReader();
        var secretConnection = reader.ReadSection<Connectionstrings>("Connectionstrings").DefaultConnection;
        var secretMailValues = reader.ReadSection<MailSettings>("MailSettings");

        AnsiConsole.MarkupLine($"[bold yellow]Connection String:[/] {secretConnection}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings From:[/] {secretMailValues.FromAddress}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Port:[/] {secretMailValues.Port}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Pickup:[/] {secretMailValues.PickupFolder}");

        ExitPrompt();
    }
}
```