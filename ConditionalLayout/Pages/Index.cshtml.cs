﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConditionalLayout.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    //public void OnGet() { }
    public ContentResult Get()
    {
        return new ContentResult
        {
            ContentType = "text/html",
            Content = "a <br /> b"
        };

    }
}
