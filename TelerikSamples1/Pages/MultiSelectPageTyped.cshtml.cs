using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TelerikSamples1.Classes;

#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class MultiSelectPageTypedModel : PageModel
    {
        [BindProperty]
        public string Countries { get; set; }
        public void OnGet()
        {

        }

        public RedirectToPageResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Countries))
            {
                Log.Information("Nothing selected");
            }
            else
            {
                var identifiers = Array.ConvertAll(Countries.Split(','), item =>
                    int.TryParse(item, out var id) ? id : 0);

                Log.Information(string.Join(" ", identifiers));
            }

            Log.Information(new string('_', 50));
            return RedirectToPage("/Index");
        }
    }
}
