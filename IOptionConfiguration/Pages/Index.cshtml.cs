using IOptionConfiguration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;

#pragma warning disable CS8618

namespace IOptionConfiguration.Pages;
public class IndexModel : PageModel
{
    
    private readonly ApplicationSettingsOptions _options;
    [BindProperty]
    public string ConnectionString { get; set; }
    public IndexModel(IOptions<ApplicationSettingsOptions> options)
    {
        _options = options.Value;
        ConnectionString = _options.DefaultConnection;

        Log.Information("Name {N1}", _options.Name);
    }

    public void OnGet()
    {

    }
}
