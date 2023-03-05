using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages
{
    public class IntroductionModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string fullName = Request.Form["FullName"];
            string url = "./ShowName?FullName=" + fullName;
            Response.Redirect(url);
        }
    }
}
