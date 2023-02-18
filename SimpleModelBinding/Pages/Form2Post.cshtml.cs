using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SimpleModelBinding.Models;
using System.Text.Json;

namespace SimpleModelBinding.Pages
{
    public class Form2PostModel : PageModel
    {
        public Person Person { get; set; }
        public void OnGet(string person)
        {
            Person = JsonSerializer.Deserialize<Person>(person);
            Log.Information("Introduction as json {P1}{P2}", Environment.NewLine, person);
            ViewData["json"] = person;
        }
    }
}
