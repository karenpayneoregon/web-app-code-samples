using CheckedListBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

#pragma warning disable CS8618

namespace CheckedListBox.Pages;
public class IndexModel : PageModel
{

    [BindProperty]
    public ServiceItem ServiceItem { get; set; }

    [BindProperty]
    public List<string> AreTypes { get; set; }

    [BindProperty]
    public List<SelectListItem> JobTypes { get; set; }
    
    public IActionResult OnGet()
    {
        LoadJobTypes();

        return Page();
    }

    public Task<IActionResult> OnPostAsync()
    {
        var test = HttpContext.Request.Form["AreTypes"].ToArray();
        ServiceItem.JobType = string.Join(",", AreTypes.ToArray());

        LoadJobTypes();

        if (!string.IsNullOrWhiteSpace(ServiceItem.JobType))
        {
            Log.Information("Selected in index post");
            Log.Information(ServiceItem.JobType);

            foreach (var areType in AreTypes)
            {
                var item = JobTypes.FirstOrDefault(x => x.Text == areType);
                if (item is not null)
                {
                    Log.Information("\tID: {P} Name: {name}", Convert.ToInt32(item.Value), item.Text);
                }
                
            }
        }
        else
        {
            Log.Information("Nothing selected in index post");
        }
        
        

        return Task.FromResult<IActionResult>(Page());

    }

    private void LoadJobTypes()
    {
        JobTypes = new List<SelectListItem>()
        {
            new() { Text = "Headlights", Value = "1" },
            new() { Text = "Brake Light Switches", Value = "2" },
            new() { Text = "Wiper Switches", Value = "3" },
            new() { Text = "Door Jamb Switches", Value = "4" }
        }.OrderBy(x => x.Text).ToList();
    }


}
