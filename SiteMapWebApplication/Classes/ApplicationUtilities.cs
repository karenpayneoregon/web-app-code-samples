using AspNetCore.SEOHelper.Sitemap;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiteMapWebApplication.Classes;

public class ApplicationUtilities
{
    /// <summary>
    /// Create sitemap.xml
    /// </summary>
    public static void GenerateSiteMap(IWebHostEnvironment environment, EndpointDataSource endpointDataSource)
    {
        var availablePages = Pages(endpointDataSource);
        List<SitemapNode> siteMapNodes = new();

        foreach (var page in availablePages)
        {
            siteMapNodes.Add(new SitemapNode()
            {
                LastModified = DateTime.UtcNow,
                Priority = 0.8,
                Frequency = SitemapFrequency.Monthly,
                Url = page
            });
        }
        
        new SitemapDocument().CreateSitemapXML(siteMapNodes, environment.ContentRootPath);
        List<SitemapNode>? items = new SitemapDocument().LoadFromFile(environment.ContentRootPath);

    }

    /// <summary>
    /// Get all pages that can be navigated too.
    /// </summary>
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

    public static string CleansePageName(string pageName) 
        => pageName.Replace("/Pages/", "/").Replace(".cshtml", "");
}
