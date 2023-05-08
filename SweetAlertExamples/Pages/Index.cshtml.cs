using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace SweetAlertExamples.Pages;
public class IndexModel : PageModel
{

    public void OnGet()
    {
        @ViewData["MessageFromOnGet"] = "Hello from OnGet";
    }
    [BindProperty]
    public string? IpAddress { get; set; }

    public void OnPost()
    {
        Log.Information("IpAddress: {P1}", IpAddress);
    }
}
