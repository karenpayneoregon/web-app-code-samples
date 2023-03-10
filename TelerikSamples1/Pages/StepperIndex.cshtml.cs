using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class StepperIndexModel : PageModel
    {        
        public bool Label { get; set; }
        public bool Indicator { get; set; }

        [BindProperty]
        public double Index { get; set; }
        public Dictionary<string, bool> StepsDictionary { get; set; }
        public void OnGet()
        {            
            Label = true;
            Indicator = false;

        }

        public StepperIndexModel()
        {
            StepsDictionary = new()
            {
                { "Step 1", true },
                { "Step 2", false },
                { "Step 3", false },
                { "Step 4", false },
                { "Step 5", false },
                { "Step 6", false }
            };
        }
        public IActionResult OnPost()
        {
            /*
             * Increment by 1 so in the next page we get 'Step N' as 
             */
            return RedirectToPage("/StepperIndexNext", new { index = Index +1 });
        }
    }
}
