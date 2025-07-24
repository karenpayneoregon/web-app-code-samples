
using SecretsApp.Classes;

namespace SecretsApp;
internal partial class Program
{


    static void Main(string[] args)
    {

        var connectionString = SecretApplicationSettingReader.Instance.ConnectionString;
        var mailSettings = SecretApplicationSettingReader.Instance.MailSettings;

        AnsiConsole.MarkupLine($"[bold yellow]Connection String:[/] {connectionString}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings From:[/] {mailSettings.FromAddress}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Port:[/] {mailSettings.Port}");
        AnsiConsole.MarkupLine($"[bold yellow]Mail Settings Pickup:[/] {mailSettings.PickupFolder}");

        ExitPrompt();
    }


}
