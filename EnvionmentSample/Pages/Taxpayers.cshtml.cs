using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace EnvironmentApplication.Pages
{
    public class TaxpayersModel : PageModel
    {
        private readonly OedContext _context;

        public TaxpayersModel(OedContext context)
        {
            _context = context;
        }

        public IList<Taxpayer> Taxpayer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Taxpayer != null)
            {
                Taxpayer = await _context.Taxpayer
                .Include(t => t.Category)
                .ToListAsync();
            }
        }
    }
}
