﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace Localization1.Pages;
public class PrivacyModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int? Id { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Name { get; set; }

    public void OnGet(int id, string name)
    {

    }
}

