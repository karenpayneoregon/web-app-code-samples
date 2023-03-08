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
        public double Value { get; set; }
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
                { "Step 1", false },
                { "Step 2", false },
                { "Step 3", false },
                { "Step 4", false },
                { "Step 5", false },
                { "Step 6", false }
            };
        }
        public void OnPost()
        {
            Log.Information("Step: {P1}", Value +1);
        }
    }
}
