using HoursApplication.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace HoursApplication.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet(TimeSpan sender)
        {
            Log.Information("From about {P1}", sender.FormatAmPm());
        }
    }
}
