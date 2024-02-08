using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace WebApplication1.Pages;
public class IndexModel : PageModel
{
    private readonly IEnumerable<EndpointDataSource> _endpointSources;
    public IEnumerable<RouteEndpoint> EndpointSources { get; set; }
    public IndexModel(IEnumerable<EndpointDataSource> endpointSources)
    {
        _endpointSources = endpointSources;
        EndpointSources = _endpointSources
            .SelectMany(x => x.Endpoints)
            .OfType<RouteEndpoint>();
    }

    public void OnGet()
    {
        //foreach (RouteEndpoint rep in EndpointSources)
        //{
        //    Log.Information("{P1,-50} {P2}", rep.RoutePattern.RawText, rep.DisplayName);
        //}
    }
}
