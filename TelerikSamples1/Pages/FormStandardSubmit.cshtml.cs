using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using TelerikSamples1.Models;
#pragma warning disable CS8618

namespace TelerikSamples1.Pages
{
    public class FormStandardSubmitModel : PageModel
    {
        [BindProperty]
        public OrderViewModel Order { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
            if (Order == null)
            {
                Order = new OrderViewModel()
                {
                    OrderDate = DateTime.Now,
                    Freight = 12.99m
                };
            }
        }

        public IActionResult OnPost()
        {
            var model = Request.Form;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Log.Information("Order {P1}", Order);
            return RedirectToPage("Success");

        }
    }
}
