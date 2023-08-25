using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Serilog;
using TelerikSamples1.Classes;
using TelerikSamples1.Models;

/*
 * A quick-n-dirty mock-up for an article I'm writing
 * Just need the screen, not code.
 */

using F = System.IO;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace TelerikSamples1.Pages
{
    public class MultiSelectCustomersPageModel : PageModel
    {
        public string FileName => "Customers.json";
        [BindProperty]
        public string CompanyNames { get; set; }
        [BindProperty]
        public string Optional { get; set; }

        public List<string> CustomersList { get; set; }

        [BindProperty]
        public List<Customer> Customers { get; set; }
        public void OnGet()
        {
            CustomersList = Customers.Select(x => x.Name).ToList();
        }

        public RedirectToPageResult OnPost()
        {
            
            if (CompanyNames is not null)
            {
                List<int> identifiers = new();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(F.File.ReadAllText(FileName))!;
                var names = CompanyNames.Split(',').ToList();
                foreach (var name in names)
                {
                    var id = Customers.FirstOrDefault(x => x.Name == name)!.Id;
                    identifiers.Add(id);
                }

                Log.Information("Identifiers {P}", string.Join(",", identifiers));
            }
            else
            {
                Log.Information("No selections made");
            }
            
            return RedirectToPage("/Index");
        }

        public MultiSelectCustomersPageModel()
        {
            if (!F.File.Exists(FileName))
            {
                string jsonString = JsonConvert.SerializeObject(BogusOperations.Customers(50), Formatting.Indented);
                F.File.WriteAllText(FileName, jsonString);
            }

            Customers = JsonConvert.DeserializeObject<List<Customer>>(F.File.ReadAllText(FileName))!;
        }
    }
}
