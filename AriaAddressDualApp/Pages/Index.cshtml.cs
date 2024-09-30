using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AriaAddressDualApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
