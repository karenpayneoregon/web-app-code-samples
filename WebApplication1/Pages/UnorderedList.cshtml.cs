using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;
public class UnorderedListModel : PageModel
{
    private readonly ILogger<UnorderedListModel> _logger;

    public UnorderedListModel(ILogger<UnorderedListModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

