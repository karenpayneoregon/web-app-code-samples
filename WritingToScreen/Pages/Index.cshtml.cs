using Microsoft.AspNetCore.Mvc.RazorPages;

#pragma warning disable CS8618

namespace WritingToScreen.Pages;
public class IndexModel : PageModel
{

    public string Message { get; set; }

    public void OnGet()
    {

    }
    public void OnPostButton1(IFormCollection data)
    {
        Message = "<br><span style=\"color: red\">Why do programmers prefer using the dark mode?</span><br><span style=\"color: blue; font-weight: bold\"> Because light attracts bugs.</span><hr>";
    }

}
