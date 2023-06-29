using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
namespace FirstApp.Pages;

public class IndexModel : PageModel
{
    public IndexModel()
    {
        Log.Information("Greetings");
    }

    public void OnGet()
    {
        
    }
}
