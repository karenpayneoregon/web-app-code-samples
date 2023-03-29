using CheckboxAriaApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace CheckboxAriaApplication.Pages;

public class IndexModel : PageModel
{
    public List<ItemContainer> List { get; set; }

    [BindProperty]
    public bool LettuceCheckbox { get; set; }

    [BindProperty]
    public bool TomatoCheckbox { get; set; }

    [BindProperty]
    public bool MustardCheckbox { get; set; }

    [BindProperty]
    public bool SproutsCheckbox { get; set; }
    public IndexModel()
    {
        List = MockedData.List();
    }

    public void OnGet()
    {

    }

    public void OnPost(IFormCollection data)
    {
        // alternate way to get at data but not recommended s
        //var result1 = Request.Form["SproutsCheckbox"];
        //var result2 = data["SproutsCheckbox"];

        Log.Information("{P1} - {P2}", nameof(LettuceCheckbox).SplitCamelCase("-"),LettuceCheckbox);
        Log.Information("{P1} - {P2}", nameof(TomatoCheckbox).SplitCamelCase("-"), TomatoCheckbox);
        Log.Information("{P1} - {P2}", nameof(MustardCheckbox).SplitCamelCase("-"), MustardCheckbox);
        Log.Information("{P1} - {P2}", nameof(SproutsCheckbox).SplitCamelCase("-"), SproutsCheckbox);
    }

}
