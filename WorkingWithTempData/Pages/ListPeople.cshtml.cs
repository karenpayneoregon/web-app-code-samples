using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Bogus;
using WorkingWithTempData.Classes;
using WorkingWithTempData.Data;
using Person = WorkingWithTempData.Models.Person;

namespace WorkingWithTempData.Pages
{
    public class ListPeopleModel : PageModel
    {
        private readonly Context _context;

        public ListPeopleModel(Context context)
        {
            _context = context;
            CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(1));

            var success = context.CanConnectAsync(cancellationTokenSource.Token);

            if (success == false)
            {
                Log.Information("Creating and populating database");
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();
            }

        }
        
        public List<Person> People { get;set; }

        [BindProperty]
        public Person Person { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                await LoadPeople();
                
            }
        }

        private async Task LoadPeople()
        {
            People = await _context.Person.ToListAsync();
            Person = People.PickRandom();
            Log.Information("Name {P1} {P2}", Person.FirstName, Person.LastName);
        }

        /// <summary>
        /// Mocked up data is set to TempData which is picked up in Index Page
        /// </summary>
        public Task<IActionResult> OnPostToIndex()
        {
            var faker = new Faker();

            var userName = Enumerable.Range(1, 2)
                .Select(_ => faker.Person.UserName)
                .FirstOrDefault();

            Random rnd = new();
            
            TempData["SomeValue"] = rnd.Next(52);
            TempData["UserName"] = userName;
            TempData.Put("person", Person);

            Log.Information("SomeValue: {P1}", TempData["SomeValue"]);
            Log.Information("UserName: {P1}", TempData["UserName"]);
            Log.Information("Person: Name {P1}", Person);

            return Task.FromResult<IActionResult>(RedirectToPage("/Index"));
        }
    }
}
