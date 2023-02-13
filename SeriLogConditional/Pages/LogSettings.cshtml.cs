using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeriLogConditional.Classes;
using SeriLogConditional.Data;

namespace SeriLogConditional.Pages;

public class LogSettingsModel : PageModel
{
    IConfigurationRoot _configuration = Configurations.GetLogConfigurationRoot();

    [BindProperty]
    public bool Logging { get; set; }
    public void OnGet()
    {
        //Logging = Convert.ToBoolean(_configuration.GetSection("Debug")["LogSqlCommand"]);

        using var context = new Context();
        Logging = context.LogSettings.FirstOrDefault()!.LogSqlCommand;
    }

    public void OnPost()
    {
        using var context = new Context();
        context.LogSettings.FirstOrDefault()!.LogSqlCommand = Logging;
        context.SaveChanges();
        //SetupLogging.Save(Logging);
    }
}