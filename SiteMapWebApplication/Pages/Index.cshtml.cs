using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteMapWebApplication.Classes;
#pragma warning disable CS8618

namespace SiteMapWebApplication.Pages;
public class IndexModel : PageModel
{

    private static EndpointDataSource _endpointDataSource;
    private IWebHostEnvironment _environment;
    public IndexModel(EndpointDataSource endpointDataSource, IWebHostEnvironment environment)
    {
        _endpointDataSource = endpointDataSource;
        _environment = environment;
    }
    public void OnGet()
    {

    }

    public void OnPost()
    {
        ApplicationUtilities.GenerateSiteMap(_environment, _endpointDataSource);
    }
}
