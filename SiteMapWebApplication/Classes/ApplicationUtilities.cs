using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Serilog;

namespace SiteMapWebApplication.Classes;

public class ApplicationUtilities
{
    public static void GenerateSiteMap(IWebHostEnvironment env, EndpointDataSource endpointDataSource)
    {
        var availablePages = Pages(endpointDataSource);
        Log.Information("Available pages {c1}", availablePages.Count);
        
        foreach (var page in availablePages)
        {
            Log.Information("  {P}", page);
        }

        var list = new List<SitemapNode>
        {
            new()
            {
                LastModified = DateTime.UtcNow, Priority = 0.8, Url = "https://www.example.com/page 1",
                Frequency = SitemapFrequency.Daily
            },
            new()
            {
                LastModified = DateTime.UtcNow, Priority = 0.9, Url = "https://www.example.com/page2",
                Frequency = SitemapFrequency.Yearly
            }
        };

        new SitemapDocument().CreateSitemapXML(list, env.ContentRootPath);
        List<SitemapNode>? items = new SitemapDocument().LoadFromFile(env.ContentRootPath);

        Log.Information("Page count {C1}", items.Count);
    }

    /// <summary>
    /// Get all pages that can be navigated too.
    /// </summary>
    /// <param name="endpointDataSource"></param>
    /// <returns></returns>
    /// <remarks>See _ViewImports.cshtml</remarks>
    public static HashSet<string> Pages(EndpointDataSource endpointDataSource)
    {
        HashSet<string> pages = new();

        foreach (var endpoint in endpointDataSource.Endpoints)
        {
            foreach (var metadata in endpoint.Metadata)
            {
                if (metadata is PageActionDescriptor pad)
                {
                    pages.Add(pad.RelativePath);
                }
            }
        }
        
        return pages;
    }

}
