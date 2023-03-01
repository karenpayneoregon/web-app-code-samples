using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleSubmitButtonsBasic.Data;
using MultipleSubmitButtonsBasic.Models;
using Serilog;

#pragma warning disable CS8601
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace MultipleSubmitButtonsBasic.Pages;

/// <summary>
/// Get random category,
///    on post show properties for top form
///    on post show products for bottom form
/// </summary>
public class IndexModel : PageModel
{
    private readonly Context _context;
    public IndexModel(Context context)
    {
       _context = context;
    }

    public void OnGet()
    {
        var lastCategoryId = _context.Categories.OrderByDescending(x => x.CategoryID).FirstOrDefault()!.CategoryID +1;
        Random rnd = new();
        var categoryIdentifier = rnd.Next(1, lastCategoryId);

        Categories = _context.Categories.FirstOrDefault(x => x.CategoryID == categoryIdentifier);

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
        Categories categories = _context.Categories.Find(id);

        var products = _context.Products.Where(x => x.CategoryID == categories.CategoryID).ToList();
        Log.Information("Category {P1}", categories.CategoryName);

        if (products.Any())
        {
            
            foreach (var product in products)
            {
                Log.Information("    {P1}", product.ProductName);
            }
        }
        else
        {
            Log.Information("    {P1}", "None");
        }

        return RedirectToPage();

    }
}
