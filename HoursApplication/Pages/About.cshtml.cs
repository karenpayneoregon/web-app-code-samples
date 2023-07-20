using HoursApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
#pragma warning disable CS8618

namespace HoursApplication.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public TimeSpan StartTime { get; set; }

        [BindProperty]
        public TimeSpan EndTime { get; set; }

        public string Worked { get; set; }

        public TimesContainer Container { get; set; }
        public void OnGet(string container)
        {
            Message = "Nothing to see";
            Worked = "Nada";
            if (string.IsNullOrWhiteSpace(container)) return;
            Container = JsonSerializer.Deserialize<TimesContainer>(container)!;
            StartTime = Container.StartTime;
            EndTime = Container.EndTime;
            Message = "From Index";

            var (hours, minutes) = Container.WorkedTime();

            Worked = $"Hours: {hours} minutes: {minutes}";
        }
    }
}
