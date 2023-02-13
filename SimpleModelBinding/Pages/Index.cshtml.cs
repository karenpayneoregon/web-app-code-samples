using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SimpleModelBinding.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Introduction = new Introduction();
    }

    [BindProperty]
    public Introduction Introduction { get; set; }
    public void OnGet(string introduction)
    {
        if (!string.IsNullOrWhiteSpace(introduction))
        {
            Introduction = JsonSerializer.Deserialize<Introduction>(introduction);
        }
    }
}
