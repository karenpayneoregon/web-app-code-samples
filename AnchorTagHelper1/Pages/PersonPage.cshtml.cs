using AnchorTagHelper1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages;

public class PersonPageModel : PageModel
{

    public Dictionary<string, string> routeData;
    public void OnGet()
    {
        routeData = new Dictionary<string, string>{
            {"id",$"{Person.Id}"},
            {"firstName",Person.FirstName},
            {"lastName",Person.LastName},
            {"birthDate",$"{Person.BirthDate:yyyy-MM-d}"} // must use this format
        };
    }
    [BindProperty]
    public Person Person { get; set; } = new()
    {
        Id = 22,
        FirstName = "Karen",
        LastName = "Payne",
        BirthDate = new(1956, 9, 24)
    };

    public void OnPost()
    {
        
    }



}