using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DropdownForCountries.Data;
using DropdownForCountries.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
#pragma warning disable CS8618

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
        
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string sender)
        {
            if (sender is {})
            {
                ErrorMessage = "Select a country";
            }

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

        public async Task<IActionResult> OnPostSubmit(int id)
        {
            if (id == 0)
            {
                await LoadCountries();
                Country = new Countries();
                
                
                return RedirectToPage("Example", new
                {
                    sender = "X"
                });
            }

            Country = _context.Countries.FirstOrDefault(x => x.Id == id)!;

            return RedirectToPage("Index", new
            {
                country = JsonSerializer.Serialize(
                    Country, 
                    new JsonSerializerOptions { WriteIndented = true })
            });
        }
    }
}
