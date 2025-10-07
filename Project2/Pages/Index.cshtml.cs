using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Project2.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
