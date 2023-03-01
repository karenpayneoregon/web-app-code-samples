using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleSubmitButtonsBasic.Models;
using Serilog;

namespace MultipleSubmitButtonsBasic.Pages;

/// <summary>
/// Get random category, on post show properties
/// </summary>
public class IndexModel : PageModel
{
    private readonly Data.Context _context;
    public IndexModel(Data.Context context)
    {
       _context = context;
    }

    public void OnGet()
    {
        var lastCategoryId = _context.Categories.OrderByDescending(x => x.CategoryID).FirstOrDefault()!.CategoryID +1;
        Random rnd = new();
        var categoryIdentifier = rnd.Next(1, lastCategoryId);
        Categories = _context.Categories.FirstOrDefault(x => x.CategoryID == categoryIdentifier)!;
    }
    public Categories Categories { get; set; } = default!;
    public IActionResult OnPostButton1(int id)
    {
        var cat = _context.Categories.Find(id);
        Log.Information("Id {P1} Name {P2} Description {P3}", cat!.CategoryID, cat.CategoryName, cat.Description);
        return RedirectToPage();
    }
    public IActionResult OnPostButton2(int id)
    {
        var cat = _context.Categories.Find(id);
        
        return RedirectToPage();
    }
}
