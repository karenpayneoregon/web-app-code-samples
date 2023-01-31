using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;
using WorkingWithDateTime.Models;

namespace WorkingWithDateTime.Pages
{
    public class ReceivingModel : PageModel
    {
        [BindProperty]
        public AppContainer AppContainer { get; set; }
        public void OnGet()
        {
            var count = TempData.Count;
            if (TempData.Count == 1 && TempData.ContainsKey("container"))
            {
                AppContainer = TempData.Get<AppContainer>("container");
                TempData.Clear();
            }
        }
    }
}
