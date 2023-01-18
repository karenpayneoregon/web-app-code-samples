using Microsoft.AspNetCore.Mvc.RazorPages;
using Revenue.Configuration.Core1;
using Revenue.Configuration.Core1.Models;

namespace WebApplication1.Pages
{
    
    public class ApplicationSettingsModel : PageModel
    {
        private readonly SettingsManager _settingManager;
        public string ServicePath { get; set; }
        public AzureSettings AzureSettings { get; set; }
        public GeneralSettings GeneralSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public WebPageSettings WebPageSettings { get; set; }

        public ApplicationSettingsModel(SettingsManager settingsManager)
        {
            _settingManager = settingsManager;
            ServicePath = _settingManager.ServicePath;
            AzureSettings = _settingManager.AzureSettings;
            GeneralSettings = _settingManager.GeneralSettings;
            MailSettings = _settingManager.MailSettings;
            WebPageSettings = _settingManager.WebPageSettings;

        }

        public void OnGet()
        {
        }
    }
}
