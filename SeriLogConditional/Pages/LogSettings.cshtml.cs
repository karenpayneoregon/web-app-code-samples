using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeriLogConditional.Classes;

namespace SeriLogConditional.Pages
{
    public class LogSettingsModel : PageModel
    {
        IConfigurationRoot _configuration = Configurations.GetLogConfigurationRoot();

        [BindProperty]
        public bool Logging { get; set; }
        public void OnGet()
        {
            Logging = Convert.ToBoolean(_configuration.GetSection("Debug")["LogSqlCommand"]);
        }

        public void OnPost()
        {
            SetupLogging.Save(Logging);
        }
    }
}
