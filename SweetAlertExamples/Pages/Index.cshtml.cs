using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using Serilog;

namespace SweetAlertExamples.Pages;
[IgnoreAntiforgeryToken] 
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


