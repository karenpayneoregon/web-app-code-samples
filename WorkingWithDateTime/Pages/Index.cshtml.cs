using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WorkingWithDateTime.Models;

namespace WorkingWithDateTime.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public AppContainer AppContainer { get; set; }

    [BindProperty, DataType("week")]
    public DateTime Week { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

        AppContainer = new AppContainer()
        {
            DateTime1 = new DateTime(2023, 2, 12),
            DateTime2 = new DateTime(2023, 2, 15),
            DateTime3 = new DateTime(2023, 2, 15),
            DateTime4 = new DateTime(2023, 2, 15),
            TimeOnly1 = new TimeOnly(14,15,0)
        };

        // for DateTime4 - see comments in OnPost
        Week = new DateTime(2023, 2, 15);

    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        /*
         * Have to manipulate Week to get year/month else receiving page will not translate correctly
         */
        var week = Request.Form[nameof(Week)].First().Split("-W");
        Week = ISOWeek.ToDateTime(Convert.ToInt32(week[0]), Convert.ToInt32(week[1]), DayOfWeek.Monday);

        AppContainer.DateTime4 = Week;
        TempData.Put("container", AppContainer);

        return RedirectToPage("Receiving");
    }
}
