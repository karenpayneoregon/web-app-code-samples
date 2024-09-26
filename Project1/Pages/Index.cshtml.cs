using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Project1.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
    }
}
