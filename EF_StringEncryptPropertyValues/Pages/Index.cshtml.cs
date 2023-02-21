using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace EF_StringEncryptPropertyValues.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public IActionResult OnGet()
    {
        Log.Information("Redirecting...");
        return new RedirectToPageResult("/UsersList");
    }
}
