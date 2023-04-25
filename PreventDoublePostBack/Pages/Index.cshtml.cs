﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PreventDoublePostBack.Models;

namespace PreventDoublePostBack.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    [TempData]
    public string Name { get; set; }
    public void OnPostSubmit(PersonModel person)
    {
        Name = $"Name: {person.FirstName} {person.LastName}";
        ViewData["JavaScript"] = "window.location = '" + Url.Page("Index") + "'";
    }
    public void OnPost(PersonModel person)
    {
        Name = $"Name: {person.FirstName} {person.LastName}";
        ViewData["JavaScript"] = "window.location = '" + Url.Page("Index") + "'";
    }
}