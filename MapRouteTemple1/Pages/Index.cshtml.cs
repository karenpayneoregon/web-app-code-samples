using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemple1.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public ArticleInformation Information { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;

        Information = new ArticleInformation() {Day = 12, Month = 4, Year = 2023, Title = "Learning Visual Studio", Active = true};
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        //RedirectToPage("DateArticle", new { Year = 2023, Month = 9, Day = 8 });
    }
}

public class ArticleInformation
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Day { get; set; }
    public bool Active { get; set; }
}
