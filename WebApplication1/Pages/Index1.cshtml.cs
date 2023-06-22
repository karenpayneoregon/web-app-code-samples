using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618
#pragma warning disable CS8600

namespace WebApplication1.Pages
{
    public class Index1Model : PageModel
    {
        [BindProperty]
        public int UserId { get; set; }
        public void OnGet()
        {

            string userData = Request.Cookies["myUserData"];
            LocalResponse? userAuthResponse = JsonSerializer.Deserialize<LocalResponse>(userData);
            Debug.WriteLine(userAuthResponse);
            UserId = userAuthResponse!.UserId;
        }

        public PageResult OnPostButton2()
        {
            LocalResponse response = new LocalResponse() { UserId = UserId, Name = "Karen" };
            var result = JsonSerializer.Serialize(response);
            Response.Cookies.Append("myUserData", result);
            return Page();
        }

        public IActionResult OnPostButton1(IFormCollection data)
        {
            Response.Cookies.Delete("myUserData");
            return Page();
        }
    }

    public class LocalResponse
    {
        
        public int UserId { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"{UserId,-6}{Name}";

    }
}
