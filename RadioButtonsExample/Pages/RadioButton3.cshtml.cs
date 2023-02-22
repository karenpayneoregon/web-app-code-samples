using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

#pragma warning disable CS8618

namespace RadioButtonsExample.Pages;

public class RadioButton3Model : PageModel
{
    [BindProperty]
    public CodingLookup CodingLookup { get; set; }
    public void OnGet()
    {
        if (Program.Shown) return;
        ViewData["Message"] = "See console window after submitting.";
        Program.Shown = true;
    }

    public void OnPost(string option)
    {

        switch (option)
        {
            case "option0":
                CodingLookup = new CodingLookup()
                {
                    EmployeeInfos = { new EmployeeInfo() {EmployeeInfoId = 1} },
                    Option1 = true
                };
                Log.Information("Option1 {P1}", CodingLookup.Option1);
                break;
            case "option1":
                CodingLookup = new CodingLookup()
                {
                    EmployeeInfos = { new EmployeeInfo() { EmployeeInfoId = 1 } },
                    Option2 = true
                };
                Log.Information("Option2 {P1}", CodingLookup.Option2);
                break;
            case "option2":
                CodingLookup = new CodingLookup()
                {
                    EmployeeInfos = { new EmployeeInfo() { EmployeeInfoId = 1 } },
                    Option3 = true
                };
                Log.Information("Option3 {P1}", CodingLookup.Option3);
                break;
            case "option3":
                CodingLookup = new CodingLookup()
                {
                    EmployeeInfos = { new EmployeeInfo() { EmployeeInfoId = 1 } },
                    Option4 = true
                };
                Log.Information("Option4 {P1}", CodingLookup.Option4);
                break;
            default:
                Log.Information("Nothing");
                break;
        }

        Log.Information("");

    }
}

public partial class EmployeeInfo
{

    public int EmployeeInfoId { get; set; }
    public virtual CodingLookup? CodingLookup { get; set; }
}

public class CodingLookup
{
    public int CodingLookupId { get; set; }

    public bool Option1 { get; set; }

    public bool Option2 { get; set; }
    public bool Option3 { get; set; }

    public bool Option4 { get; set; }

    public virtual List<EmployeeInfo> EmployeeInfos { get; } = new();
}