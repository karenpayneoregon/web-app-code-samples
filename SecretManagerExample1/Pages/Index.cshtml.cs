using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CA2254
#pragma warning disable CS8618

namespace SecretManagerExample1.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _config;
    [BindProperty]
    public string? SecretKey { get; set; }
    public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;

    }

    public void OnGet()
    {
        var key = _config["googleMapApi:apiKey"];
        _logger.LogInformation(key);
        SecretKey = key;
    }
}
