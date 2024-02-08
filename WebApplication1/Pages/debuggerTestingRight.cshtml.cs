using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace WebApplication1.Pages
{
    public class debuggerTestingRightModel : PageModel
    {
        [BindProperty]
        public required OrderForm Form { get; set; } 

        [BindProperty]
        public List<US_State> UnitedStates { get; set; }
        public List<SelectListItem> Options { get; set; }

        [BindProperty]
        public int CurrentStateIdentifier { get; set; }
        public void OnGet()
        {
            UnitedStates = StateArray.States(true);

            Options = UnitedStates.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        /// <summary>
        /// Example to get information entered, in this case for
        /// <see cref="OrderForm.BusinessName"/> and select state identifier
        /// No validation on if a state was selected, for this we add validation e.g. FluentValidation or data annotations
        /// then check model state is valid or not
        /// </summary>
        /// <param name="id">current state identifier</param>
        public RedirectToPageResult OnPost(int id)
        {
            var result = StateArray.States(true).FirstOrDefault(x => x.Id == id);
            Log.Information("Business name: {P1,-20} Current state id: {P2,-3} State name: {P3}", Form.BusinessName, id, result!.Name);
            return RedirectToPage("/Index");
        }
    }
}
