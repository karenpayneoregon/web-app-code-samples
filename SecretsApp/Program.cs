using SecretsApp.Classes;
using SecretsApp.Models;
using System.Reflection;


namespace SecretsApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        var reader = new SecretApplicationSettingReader();
        var connection = reader.ReadSection<Connectionstrings>(nameof(Connectionstrings))
            .DefaultConnection;

        var mail = reader.ReadSection<MailSettings>(nameof(MailSettings));

        AnsiConsole.MarkupLine($"[bold yellow]Connection String:[/] {connection}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings From:[/] {mail.FromAddress}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Port:[/] {mail.Port}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Pickup:[/] {mail.PickupFolder}");

        
        ExitPrompt();
    }
}