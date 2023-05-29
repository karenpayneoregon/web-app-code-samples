using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Serilog;
using WorkingWithTempData.Classes;
using WorkingWithTempData.Models;


namespace WorkingWithTempData.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public Person Person { get; set; }
    [Display(Name = "Value")]
    public int SomeValue { get; set; }
    [Display(Name = "User name")]
    public string UserName { get; set; }
    [Display(Name = "Count")]
    public int TempDataCount { get; set; }
    [TempData, BindProperty]
    public string PageTitle { get; set; }

    public IndexModel()
    {
        Person = new Person();
        PageTitle = "Demo";
    }

    public void OnGet()
    {

        // test values set in ListPeople page for exact count
        if (TempData.Count == 3)
        {
            Log.Information("OnGet IndexPage");
            SomeValue = int.Parse(TempData[nameof(SomeValue)].ToString()!);
            UserName = TempData[nameof(UserName)].ToString();
            Person = TempData.Get<Person>("person");
        }

        // here we only need to above once so clear the items
        TempData.Clear();
        // since we just cleared TempData the count will be zero.
        TempDataCount = TempData.Count;
        
    }
}
