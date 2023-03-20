using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteMapWebApplication.Classes;

namespace SiteMapWebApplication.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private static EndpointDataSource _endpointDataSource;
    public IndexModel(ILogger<IndexModel> logger, EndpointDataSource endpointDataSource)
    {
        _logger = logger;
        _endpointDataSource = endpointDataSource;
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        var resultHashSet = ApplicationUtilities.Pages(_endpointDataSource);
    }


}
