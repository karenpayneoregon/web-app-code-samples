using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorLibrary.Classes;
using WorkingWithTempData.Classes;
using WorkingWithTempData.Data;
using WorkingWithTempData.Models;

namespace WorkingWithTempData.Pages
{
    public class ListPeopleModel : PageModel
    {
        private readonly Context _context;

        public ListPeopleModel(Context context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                Person = await _context.Person.ToListAsync();
            }
        }

        /// <summary>
        /// Mocked up data is set to TempData which is picked up in Index Page
        /// </summary>
        public IActionResult OnPostToIndex()
        {
            Random rnd = new Random();
            var person = _context.Person.ToList().MinBy(r => Guid.NewGuid());
            TempData["SomeValue"] = rnd.Next(52);
            TempData["UserName"] = "billyBob";
            TempData.Put("person", person);

            return RedirectToPage("/Index");
        }
    }
}
