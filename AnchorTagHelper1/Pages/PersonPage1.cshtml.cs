using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class PersonPage1Model : PageModel
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

        }

        [BindProperty]
        public Person Person { get; set; } = default!;
    }
}
