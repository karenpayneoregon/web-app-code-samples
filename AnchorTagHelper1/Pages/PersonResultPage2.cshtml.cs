using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace AnchorTagHelper1.Pages
{
    public class PersonResultPage2Model : PageModel
    {
        public void OnGet(int id, string firstName, string lastName, DateTime birthDate)
        {
            Person = new Person
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate
            };

            Log.Information("In Result page");

        }


        [BindProperty]
        public Person Person { get; set; } = default!;
    }
}
