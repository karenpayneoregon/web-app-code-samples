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

        [BindProperty]
        public List<FormType> FormTypes { get; set; }
        [BindProperty]
        public List<SelectListItem> FormTypeOptions { get; set; }
        [BindProperty]
        public int CurrentFormTypeIdentifier { get; set; }

        public void OnGet()
        {
            UnitedStates = StateArray.States(true);

            Options = UnitedStates.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();

            FormTypeOptions = MockedForms.AvailableFormTypes().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.FormName
            }).ToList();
        }

        /// <summary>
        /// Example to get information entered, in this case for
        /// <see cref="OrderForm.BusinessName"/> and select state identifier
        /// No validation on if a state was selected, for this we add validation e.g. FluentValidation or data annotations
        /// then check model state is valid or not
        /// </summary>
        /// <param name="id">current state identifier</param>
        public RedirectToPageResult OnPost(int id, int id1)
        {
            var state = StateArray.States(true).FirstOrDefault(x => x.Id == id);
            var form = MockedForms.AvailableFormTypes().FirstOrDefault(x => x.Id == id1);

            Log.Information("Form name: {F1}", form!.FormName);

            Form.CurrentState = state!.Name;
            Log.Information(ObjectDumper.Dump(Form));

            return RedirectToPage("/Index");
        }
    }
}
