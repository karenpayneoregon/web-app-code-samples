using Bogus.Bson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Serilog;
using System.Text.Json;
using TelerikSamples1.Classes;
using TelerikSamples1.Models;

using F = System.IO;
#pragma warning disable CS8602

#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class MultiSelectPageTypedModel : PageModel
    {
        public string FileName => "Countries.json";
        [BindProperty]
        public string Countries { get; set; }
        [BindProperty]
        public List<Country> CountryList { get; set; }
        public void OnGet()
        {
            
        }

        public MultiSelectPageTypedModel()
        {

            if (!F.File.Exists(FileName))
            {
                string jsonString = JsonConvert.SerializeObject(BogusOperations.Countries(), Formatting.Indented);
                F.File.WriteAllText(FileName, jsonString);
            }

            CountryList = JsonConvert.DeserializeObject<List<Country>>(F.File.ReadAllText(FileName))!;
        }

        public RedirectToPageResult OnPost()
        {
            Log.Information(new string('_', 50));

            if (string.IsNullOrWhiteSpace(Countries))
            {
                Log.Information("Nothing selected");
            }
            else
            {
                CountryList = JsonConvert.DeserializeObject<List<Country>>(F.File.ReadAllText(FileName))!;
                var identifiers = Array.ConvertAll(Countries.Split(','), item =>
                    int.TryParse(item, out var id) ? id : 0);
                
                Log.Information("Selections");

                foreach (var identifier in identifiers)
                {
                    Log.Information("{P1} {P2}", identifier, CountryList.FirstOrDefault(x =>x.Id == identifier).Text);
                }
            }

            Log.Information(new string('_', 50));
            return RedirectToPage("/Index");
        }
    }
}
