using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace SweetAlertExamples.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        @ViewData["MessageFromOnGet"] = "Hello from OnGet";
    }
    [BindProperty]
    public string? IpAddress { get; set; }
    [BindProperty]
    public string? Password { get; set; }


    public void OnPostAskForIpAddress()
    {
        Log.Information("IP Address: {P1}", IpAddress);
    }

    public void OnPostGetEnteredPassword()
    {
        Log.Information("Password: {P1}", Password);
    }
}
