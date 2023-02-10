using System.Text.Json;
using MapRouteTemplate2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MapRouteTemplate2.Pages
{
    public class View1Model : PageModel
    {

        [BindProperty]
        public Person? Person { get; set; }
        
        public void OnGet(string person)
        {
            Person = JsonSerializer.Deserialize<Person>(person);
        }
    }
}
