using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Revenue.Configuration.Core1;
using Revenue.Configuration.Core1.Models;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class ViewCategoriesModel : PageModel
{
    private readonly NorthWind2020Context _context;

    public ViewCategoriesModel(NorthWind2020Context context, SettingsManager settingsManager)
    {
        _context = context;
    }

    public IList<Categories> Categories { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Categories != null)
        {
            Categories = await _context.Categories.ToListAsync();
        }
    }
}