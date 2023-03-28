using CheckboxAriaApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace CheckboxAriaApplication.Pages;

public class IndexModel : PageModel
{

 
    public List<ItemContainer> List { get; set; }

    [BindProperty]
    public bool Checkbox1 { get; set; }

    [BindProperty]
    public bool Checkbox2 { get; set; }

    [BindProperty]
    public bool Checkbox3 { get; set; }

    [BindProperty]
    public bool Checkbox4 { get; set; }
    public IndexModel()
    {
        List = MockedData.List();
    }

    public void OnGet()
    {

    }

    public void OnPost()
    {
        Log.Information("{P1} - {P2}", nameof(Checkbox1),Checkbox1);
        Log.Information("{P1} - {P2}", nameof(Checkbox2),Checkbox2);
        Log.Information("{P1} - {P2}", nameof(Checkbox3),Checkbox3);
        Log.Information("{P1} - {P2}", nameof(Checkbox4),Checkbox4);
    }

}
