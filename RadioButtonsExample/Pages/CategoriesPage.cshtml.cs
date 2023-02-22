using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RadioButtonsExample.Data;
using RadioButtonsExample.Models;
using Serilog;

#pragma warning disable CS8618

namespace RadioButtonsExample.Pages;

public class CategoriesPageModel : PageModel
{
    private readonly Context _context;

    public CategoriesPageModel(Context context)
    {
        _context = context;
    }

    public IList<Categories> Categories { get; set; }

    [BindProperty]
    public int Identifier { get; set; }

    public async Task OnGetAsync()
    {
        Categories ??= await _context.Categories.ToListAsync();
    }

    public Task<IActionResult> OnPost(int? identifier)
    {
        if (identifier is not null)
        {
            Log.Information("Select Id {P1} Name {P2}",
                identifier,
                _context.Categories.FirstOrDefault(x => x.CategoryID == identifier)!.Description);
        }
        else
        {
            Log.Information("Nothing selected");
        }


        // recycle back to same page
        return Task.FromResult<IActionResult>(RedirectToPage("CategoriesPage"));
    }
}