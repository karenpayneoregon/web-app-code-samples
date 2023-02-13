
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleModelBinding.Pages;

public class Form1Model : PageModel
{
    public class Introduction
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
    public void OnGet() { }
    public void OnPost()
    {
        Introduction introduction = new()
        {
            Name = Request.Form["Name"],
            Surname = Request.Form["Surname"]
        };

        ViewData["sentence"] = $"Hi, my name is {introduction.Name} {introduction.Surname}!";
    }
}