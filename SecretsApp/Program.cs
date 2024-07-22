using SecretsApp.Classes;
using SecretsApp.Models;

namespace SecretsApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        var reader = new SecretAppSettingReader();
        var secretConnection = reader.ReadSection<Connectionstrings>("Connectionstrings")
            .DefaultConnection;

        var secretMailValues = reader.ReadSection<MailSettings>("MailSettings");

        AnsiConsole.MarkupLine($"[bold yellow]Connection String:[/] {secretConnection}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings From:[/] {secretMailValues.FromAddress}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Port:[/] {secretMailValues.Port}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Pickup:[/] {secretMailValues.PickupFolder}");

        ExitPrompt();
    }
}