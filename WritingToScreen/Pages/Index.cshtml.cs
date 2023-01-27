using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace WritingToScreen.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public string Message { get; set; }
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
    public void OnPostButton1(IFormCollection data)
    {
        Message = "<br><span style=\"color: red\">Why do programmers prefer using the dark mode?</span><br><span style=\"color: blue; font-weight: bold\"> Because light attracts bugs.</span><hr>";
    }

}
