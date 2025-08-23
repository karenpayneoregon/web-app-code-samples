using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;
using System.ComponentModel.DataAnnotations;
using WorkingWithDateTime.Models;

namespace WorkingWithDateTime.Pages
{
    public class ReceivingModel : PageModel
    {
        [BindProperty]
        public AppContainer AppContainer { get; set; }

        [BindProperty, DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        public DateTime UpDated { get; set; }

        public void OnGet()
        {

            UpDated = DateTime.Now;
            // Check if TempData contains the AppContainer object
            if (TempData.ContainsKey("container"))
            {
                AppContainer = TempData.Get<AppContainer>("container");
                TempData.Clear();
            }
            else
            {


            }
        }
    }
}
