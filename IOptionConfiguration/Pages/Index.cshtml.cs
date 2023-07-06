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

    private readonly ApplicationOptions _applicationSettings;

    private ApplicationFeatures _applicationFeatures = new();

    private readonly TopItemSettings _monthTopItem;
    private readonly TopItemSettings _yearTopItem;

    [BindProperty]
    public string ConnectionString { get; set; }

    /// <summary>
    /// Two examples for obtaining settings from appsettings.json
    /// </summary>
    /// <seealso cref="IOptionsSnapshot{T}"/> allows updates while the app is running
    /// Use caution with permitting changes
    public IndexModel(
        IOptionsSnapshot<ApplicationOptions> applicationSettings, 
        IConfiguration configuration,
        IOptionsSnapshot<TopItemSettings> topItemSettings)
    {
        _applicationSettings = applicationSettings.Value;
        ConnectionString = _applicationSettings.DefaultConnection;
        _configuration = configuration;

        
        _configuration.Bind("ApplicationFeatures:IndexPage", _applicationFeatures);

        if (_applicationFeatures.EnableLogging)
        {
            Log.Information("Name {N1}", 
                _applicationSettings.Name);

            Log.Information("Connection string from ApplicationFeatures {N2}", 
                _applicationFeatures.ConnectionString);
        }

        Title = _applicationFeatures.Title;

        _monthTopItem = topItemSettings.Get(TopItemSettings.Month);
        _yearTopItem = topItemSettings.Get(TopItemSettings.Year);


    }

    public void OnGet()
    {
        Log.Information("Month Name: {P1} Model {P2}", _monthTopItem.Name, _monthTopItem.Model);
        Log.Information("Year Name: {P1} Model {P2}", _yearTopItem.Name, _yearTopItem.Model);
    }
}
