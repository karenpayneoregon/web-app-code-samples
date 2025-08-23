using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using RazorLibrary.Classes;
using WorkingWithDateTime.Classes;
using WorkingWithDateTime.Models;

namespace WorkingWithDateTime.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public AppContainer AppContainer { get; set; }

        // Bind to custom Week type (string "yyyy-Www" -> Week via TypeConverter)
        [BindProperty]
        public Week Week { get; set; } = new();

        // Computed on POST
        public int WeekNumber { get; private set; }
        public DateTime WeekStartDate { get; private set; } // Monday of ISO week

        public void OnGet()
        {
        }

        public Index1Model()
        {
            AppContainer = new AppContainer()
            {
                DateTime1 = new DateTime(2023, 2, 12, 13, 11, 1),
                DateTime2 = new DateTime(2023, 2, 15),
                DateTime3 = new DateTime(2023, 2, 15),
                DateTime4 = DateTime.Now,
                TimeOnly1 = new TimeOnly(14, 15, 0)
            };

            // Initialize Week to the current ISO week (replaces old: Week = AppContainer.DateTime4;)
            var today = AppContainer.DateTime4;
            Week.Year = today.Year;
            Week.WeekNumber = ISOWeek.GetWeekOfYear(today);
        }

        public void OnPost()
        {

            WeekNumber = Week.WeekNumber;
            WeekStartDate = ISOWeek.ToDateTime(Week.Year, Week.WeekNumber, DayOfWeek.Monday);

            // Make available after redirect (Receiving page)
            TempData["WeekNumber"] = WeekNumber;
            TempData["WeekStartDate"] = WeekStartDate.ToString("yyyy-MM-dd");
            TempData.Put("container", AppContainer);

            Console.WriteLine($"Week number {WeekNumber}");

        }

        public IActionResult OnPostButton1(IFormCollection data)
        {
            return new RedirectToPageResult("Index");
        }
    }
}
