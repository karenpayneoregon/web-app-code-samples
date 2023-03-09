using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MultipleSubmitButtonsBasic.Data;
using MultipleSubmitButtonsBasic.Models;
#pragma warning disable CS8618

namespace MultipleSubmitButtonsBasic.Pages
{
    public class ProductsPageModel : PageModel
    {
        private readonly Context _context;
        public List<Products> List { get; set; }
        public string CategoryName { get; set; }
        public ProductsPageModel(Context context)
        {
            _context = context;
        }
        public Task<IActionResult> OnGetAsync(int? id)
        {
            CategoryName = _context.Categories.FirstOrDefault(x => x.CategoryID == id)!.CategoryName;
            List = _context.Products.Where(x => x.CategoryID == id).OrderBy(x => x.ProductName).ToList();
            return Task.FromResult<IActionResult>(Page());
        }

    }
}
