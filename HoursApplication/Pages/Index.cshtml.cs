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
    public SelectList HoursList { get; set; }
    private readonly Appsettings _appSettings;

    public TimeIncrement SelectedTimeIncrement { get; set; }

    public IndexModel(IOptions<Appsettings> appSettings)
    {
        _appSettings = appSettings.Value;
        Title = _appSettings.Title;
        
        SelectedTimeIncrement = Enum.TryParse<TimeIncrement>(_appSettings.Hours, true, out var selection) ?
            selection : 
            TimeIncrement.Hourly;
    }
    public void OnGet()
    {
        HoursList = new SelectList(Hours.Quarterly, "TimeSpan", "Text");
        HoursList.FirstOrDefault()!.Disabled = true;
        var selectedHour = HoursList.FirstOrDefault(x => x.Text == "04:30 PM");
        if (selectedHour != null) selectedHour.Selected = true;
    }
    
    public IActionResult OnPostSubmit(TimeSpan? time)
    {
        Log.Information("{P1} - {P2}", time, time!.Value.FormatAmPm());

        return RedirectToPage("About", new
        {
            sender = time
        });
    }

   
}
