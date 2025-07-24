# Copilot Instructions for SecretsApp

## Project Overview
- **SecretsApp** is a .NET 8 console application demonstrating safe storage and retrieval of secrets (e.g., connection strings, mail settings) using ASP.NET Core's User Secrets feature.
- Main configuration is in `appsettings.json` and optionally environment-specific files (e.g., `appsettings.Development.json`).
- Secrets are injected via User Secrets in development, not stored in source control.

## Key Components
- `Classes/SecretApplicationSettingReader.cs`: Singleton for reading configuration sections and properties, automatically loads User Secrets in development.
- `Models/MailSettings.cs` and `Models/Connectionstrings.cs`: Strongly-typed models for configuration sections.
- `Program.cs`: Entry point, demonstrates reading and displaying secrets using the reader and Spectre.Console for output.
- `GlobalUsings.cs`: Sets up global using directives for Spectre.Console and helpers.

## Configuration & Secrets Workflow
- Initialize secrets: `dotnet user-secrets init` (adds `<UserSecretsId>` to `.csproj`).
- Add secrets: Use `dotnet user-secrets set` or edit the secrets file via Visual Studio ("Manage User Secrets").
- List secrets: `dotnet user-secrets list`.
- Example secret structure:
  ```json
  {
    "ConnectionStrings:DefaultConnection": "...",
    "MailSettings:FromAddress": "...",
    "MailSettings:Host": "...",
    "MailSettings:Port": "...",
    "MailSettings:TimeOut": "...",
    "MailSettings:PickupFolder": "..."
  }
  ```
- Secrets are loaded only in `Development` environment (see `SecretApplicationSettingReader`).

## Build & Run
- Build: `dotnet build`
- Run: `dotnet run`
- No tests are present; focus is on configuration and secrets management.

## Patterns & Conventions
- Configuration is accessed via strongly-typed models and a singleton reader.
- Use environment variables and User Secrets for sensitive data; never commit secrets to source control.
- Output uses Spectre.Console for rich formatting.
- Helper classes (`Helpers.cs`, `SpectreConsoleHelpers.cs`) provide utility and UI functions.
- External dependencies managed via NuGet (`Spectre.Console`, `Microsoft.Extensions.Configuration.*`, custom libraries).

## Integration Points
- Relies on Microsoft.Extensions.Configuration and related packages for config loading.
- Custom libraries (`ConfigurationLibrary`, `ConsoleConfigurationLibrary`, `ConsoleHelperLibrary`) are referenced; see `.csproj` for details.

## Example Usage
```csharp
var connectionString = SecretApplicationSettingReader.Instance.ConnectionString;
var mailSettings = SecretApplicationSettingReader.Instance.MailSettings;
```

---

**If unclear or missing details, review `readme.md`, `SecretApplicationSettingReader.cs`, and `Program.cs` for current patterns.**
