using CheckedListBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable CS8618

namespace CheckedListBox.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public ServiceItem ServiceItem { get; set; }

    [BindProperty]
    public List<string> AreTypes { get; set; }

    [BindProperty]
    public List<SelectListItem> JobTypes { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        LoadJobTypes();
        return Page();
    }

    public Task<IActionResult> OnPostAsync()
    {
        ServiceItem.JobType = string.Join(",", AreTypes.ToArray());

        LoadJobTypes();

        return Task.FromResult<IActionResult>(Page());

    }

    private void LoadJobTypes()
    {
        JobTypes = new List<SelectListItem>()
        {
            new() { Text = "Headlights", Value = "Headlights" },
            new() { Text = "Brake Light Switches", Value = "BrakeLightSwitches" },
            new() { Text = "Wiper Switches", Value = "WiperSwitches" },
            new() { Text = "Door Jamb Switches", Value = "DoorJambSwitches" }
        }.OrderBy(x => x.Text).ToList();
    }
}
