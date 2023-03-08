using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace TelerikSamples1.Pages
{
    public class StepperIndexNextModel : PageModel
    {
        public bool Label { get; set; }
        public bool Indicator { get; set; }

        [BindProperty]
        public double Index { get; set; }
        public Dictionary<string, bool> StepsDictionary { get; set; }
        public void OnGet(string index)
        {
            Label = true;
            Indicator = false;

            StepsDictionary[$"Step {index}"] = true;
        }

        public StepperIndexNextModel()
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

    }
}
