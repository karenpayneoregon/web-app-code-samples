using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class IntroductionModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public void OnGet() { }
        public void OnPost()
        {
            //string fullName = Request.Form["FullName"];
            string url = $"./ShowName?FullName={FullName}";
            Response.Redirect(url);
        }
    }
}
