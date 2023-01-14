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
        private readonly ILogger<ListPeopleModel> _logger;

        public ListPeopleModel(Context context, ILogger<ListPeopleModel> logger)
        {
            _logger = logger;
            _context = context;
            CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

            var success = context.CanConnectAsync(cancellationTokenSource.Token);
            if (success == false)
            {
                _logger.LogInformation("Creating and populating database");
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
            }
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                await LoadPeople();
            }
        }

        private async Task LoadPeople()
        {
            Person = await _context.Person.ToListAsync();
        }

        /// <summary>
        /// Mocked up data is set to TempData which is picked up in Index Page
        /// </summary>
        public async Task<IActionResult> OnPostToIndex()
        {
            Random rnd = new();

            await LoadPeople();

            var person = Person.MinBy(r => Guid.NewGuid());

            TempData["SomeValue"] = rnd.Next(52);
            TempData["UserName"] = "billyBob";
            TempData.Put("person", person);

            return RedirectToPage("/Index");
        }
    }
}
