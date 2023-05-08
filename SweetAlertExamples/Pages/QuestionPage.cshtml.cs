using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

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
            Log.Information("Result {P1}", Result);
        }
    }
}
