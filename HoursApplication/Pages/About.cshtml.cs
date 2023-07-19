using HoursApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.ComponentModel.DataAnnotations;

namespace HoursApplication.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public TimeSpan StartTime { get; set; }
        public void OnGet(TimeSpan sender)
        {
            Log.Information("From about {P1}", sender.FormatAmPm());
            StartTime = sender;
        }
    }
}
