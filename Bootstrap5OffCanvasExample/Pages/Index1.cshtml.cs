using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
#pragma warning disable CS8618

namespace Bootstrap5OffCanvasExample.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public List<string> Months { get; set; }
        [BindProperty]
        public List<string> Days { get; set; }
        [BindProperty]
        public string CurrentDay { get; set; }
        public void OnGet()
        {
            Months = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1].ToList();
            Days = DateTimeFormatInfo.CurrentInfo.DayNames.ToList();
            CurrentDay = DateTime.Now.DayOfWeek.ToString();
        }
    }
}
