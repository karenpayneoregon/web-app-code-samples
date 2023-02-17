using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DropdownForCountries.Data;
using DropdownForCountries.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace DropdownForCountries.Pages
{
    public class ExampleModel : PageModel
    {
        private readonly Context _context;

        public ExampleModel(Context context)
        {
            _context = context;
        }

        public IList<Countries> Countries { get;set; } = default!;

        public SelectList CountryList { get; set; }
        [BindProperty]
        public Countries Country { get; set; }

        public async Task OnGetAsync()
        {
            await LoadCountries();
        }

        private async Task LoadCountries()
        {
            if (_context.Countries != null)
            {
                Countries = await _context.Countries.ToListAsync();
                CountryList = new SelectList(_context.Countries, "Id", "Name");
            }
        }

        public async Task<IActionResult> OnPostSubmit(int Id)
        {
            if (Id == 0)
            {
                await LoadCountries();
                return Page();
            }

            Country = _context.Countries.FirstOrDefault(x => x.Id == Id)!;
            return RedirectToPage("Index", new { country = JsonSerializer.Serialize(Country, new JsonSerializerOptions { WriteIndented = true }) });
        }
    }
}
