using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace KarenRazor.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
