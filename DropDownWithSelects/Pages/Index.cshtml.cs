using DropDownWithSelects.Data;
using DropDownWithSelects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DropDownWithSelects.Pages;
public class IndexModel : PageModel
{
    private readonly Context _context;

    private readonly ApplicationFeatures _features;
    public List<SelectListItem> Options { get; set; }
    [BindProperty]
    public int SelectedCategory { get; set; }
    // IOptionsSnapshot picks up appsettings when page loads
    public IndexModel(Context context, IOptionsSnapshot<ApplicationFeatures> features)
    {
        _context = context;
        _features = features.Get(ApplicationFeatures.Index);
        var catsCategoriesList = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        catsCategoriesList.Insert(0, new Categories() { CategoryID = -1, CategoryName = _features.SelectText });

        Options = catsCategoriesList.Select(category => new SelectListItem()
        {
            Value = category.CategoryID.ToString(),
            Text = category.CategoryName
        }).ToList();
    }

    public void OnGet()
    {
        // for an application posting place code above here
    }

    public void OnPost(int categoryId)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryID == categoryId);

        if (category == null)
        {
            Log.Warning("No selection");
        }
        else
        {
            Log.Information("Id {P1} Name {P2}", categoryId, category);
        }
        
    }
}
