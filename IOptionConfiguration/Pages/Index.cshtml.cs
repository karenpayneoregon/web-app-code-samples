using IOptionConfiguration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;


namespace IOptionConfiguration.Pages;
public class IndexModel : PageModel
{

    [ViewData]
    public string Title { get; set; }

    private readonly IConfiguration _configuration;

    private readonly ApplicationSettingsOptions _applicationSettings;

    private ApplicationFeatures _features = new ApplicationFeatures();

    [BindProperty]
    public string ConnectionString { get; set; }

    public IndexModel(IOptions<ApplicationSettingsOptions> applicationSettings, IConfiguration configuration)
    {
        _applicationSettings = applicationSettings.Value;
        ConnectionString = _applicationSettings.DefaultConnection;


        _configuration = configuration;

        
        _configuration.Bind("ApplicationFeatures:IndexPage", _features);

        if (_features.EnableLogging)
        {
            Log.Information("Name {N1}", _applicationSettings.Name);
            Log.Information("Connection string from features {N2}", _features.ConnectionString);
        }

        Title = _features.Title;

    }

    public void OnGet()
    {


    }
}
