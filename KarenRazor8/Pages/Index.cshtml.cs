using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace KarenRazor8.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
