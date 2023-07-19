using System.Globalization;
using HoursApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;
#pragma warning disable CS8618

namespace HoursApplication.Pages;
public class IndexModel : PageModel
{

    [ViewData]
    public string Title { get; set; }
    public SelectList StartHoursList { get; set; }
    private readonly Appsettings _appSettings;

    public TimeIncrement SelectedTimeIncrement { get; set; }

    /// <summary>
    /// Get option for showing hours for <seealso cref="TimeIncrement"/>
    /// </summary>
    public IndexModel(IOptions<Appsettings> appSettings)
    {
        _appSettings = appSettings.Value;
        Title = _appSettings.Title;
        
        SelectedTimeIncrement = Enum.TryParse<TimeIncrement>(_appSettings.TimeIncrement, true, 
            out var selection) ?
            selection : 
            TimeIncrement.Hourly;
    }
    public void OnGet()
    {
        StartHoursList = new SelectList(Hours.UserChoice(SelectedTimeIncrement), 
            "TimeSpan", "Text");

        StartHoursList.FirstOrDefault()!.Disabled = true;
        var selectedHour = StartHoursList.FirstOrDefault(x => x.Text == "04:30 PM");
        if (selectedHour != null) selectedHour.Selected = true;
    }

    [BindProperty]
    public TimeSpan? StartTime { get; set; }
    public IActionResult OnPostSubmit()
    {
        Log.Information("{P1} - {P2}", StartTime, StartTime!.Value.FormatAmPm());

        return RedirectToPage("About", new
        {
            sender = StartTime
        });
    }

   
}
