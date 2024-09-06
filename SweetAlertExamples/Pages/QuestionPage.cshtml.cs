using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SweetAlertExamples.Classes;

namespace SweetAlertExamples.Pages
{
    public class QuestionPageModel : PageModel
    {
        [BindProperty]
        public bool Result { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Log.Information("Delete file {P1}", Result.ToYesNo());
        }
    }
}
