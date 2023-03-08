using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TelerikSamples1.Pages
{
    public class StepperIndexModel : PageModel
    {        
        public bool Label { get; set; }
        public bool Indicator { get; set; }

        public double Value { get; set; }
        public void OnGet()
        {            
            Label = true;
            Indicator = false;
        }
    }
}
