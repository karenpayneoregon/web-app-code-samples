using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ExceptionNet8App1.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Log.Information("Greetings");
        try
        {
            throw new Exception("Exception while fetching all the students from the storage.");
        }
        catch (Exception ex)
        {
        }
    }

}
