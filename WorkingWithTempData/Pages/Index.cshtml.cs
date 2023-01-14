using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLibrary.Classes;
using System.ComponentModel.DataAnnotations;
using WorkingWithTempData.Models;


namespace WorkingWithTempData.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
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

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Person = new Person();
        PageTitle = "Demo";
    }

    public void OnGet()
    {

        // test values set in ListPeople page for exact count
        if (TempData.Count == 3)
        {
            _logger.LogInformation("OnGet IndexPage");
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
