using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using TheftReportingApp.Classes;
using TheftReportingApp.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace TheftReportingApp.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public List<US_State> UsStates { get; set; }
    public List<SelectListItem> Options { get; set; }
    public void OnGet()
    {
        UsStates = StateArray.States(true);
        Options = UsStates.Select(x => new SelectListItem()
        {
            Value = x.Abbreviation,
            Text = x.Name
        }).ToList();
    }
}
