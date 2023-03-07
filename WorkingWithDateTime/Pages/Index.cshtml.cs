using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Serilog;
using WorkingWithDateTime.Models;
using WorkingWithDateTime.Classes;

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
            DateTime1 = new DateTime(2023, 2, 12, 13,11,1),
            DateTime2 = new DateTime(2023, 2, 15),
            DateTime3 = new DateTime(2023, 2, 15),
            DateTime4 = new DateTime(2023, 2, 15),
            TimeOnly1 = new TimeOnly(14,15,0)
        };

        // for DateTime4 - see comments in OnPost
        Week = AppContainer.DateTime4;

    }

    public void OnGet()
    {

    }

    [BindProperty, DataType("week")]
    public Week CustomWeek { get; set; }

    /// <summary>
    /// Uses methods from RazorLibrary in this solution for working with TempData
    /// </summary>
    public IActionResult OnPost()
    {
        /*
         * Have to manipulate Week to get year/month else receiving page will not translate correctly
         */
        var week = Request.Form[nameof(Week)].First().Split("-W");
        Log.Information("Week array: {W}", string.Join(",", week));
        Week = ISOWeek.ToDateTime(Convert.ToInt32(week[0]), Convert.ToInt32(week[1]), DayOfWeek.Monday);

        Log.Information("Week = {W}", Week);

        AppContainer.DateTime4 = Week;
        TempData.Put("container", AppContainer);

        CustomWeek = Classes.Week.TryParse(Request.Form[nameof(Week)].First());
        
        Log.Information("Year: {P1} Week: {P2}", CustomWeek.Year, CustomWeek.WeekNumber);
        Log.Information("CustomWeek.ToString {P1}",CustomWeek.ToString());

        return RedirectToPage("Receiving");
    }

    public IActionResult OnPostButton1(IFormCollection data)
    {
        return new RedirectToPageResult("Index");
    }
}
