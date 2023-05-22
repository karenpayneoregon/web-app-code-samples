using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace SeriLogConditional.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Log.Information("Hello");
    }

    public void OnGet()
    {

    }
}
