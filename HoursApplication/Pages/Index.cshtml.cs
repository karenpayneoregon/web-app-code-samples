using System.Globalization;
using HoursApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace HoursApplication.Pages;
public class IndexModel : PageModel
{

    public SelectList HoursList { get; set; }

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
