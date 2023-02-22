using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NotesRazorApp.Data;
using NotesRazorApp.Models;

namespace NotesRazorApp.Pages
{
    public class CategoriesPageModel : PageModel
    {
        private readonly Context _context;

        public CategoriesPageModel(Context context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; }
        public void OnGet()
        {
        }
        public async Task OnGetAsync()
        {

            if (_context.Note != null)
            {
                Categories = await _context.Category.ToListAsync();
            }
        }
    }
}
