using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnchorTagHelper1.Pages;
public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public int Parm1 { get; set; }
    public int Parm2 { get; set; }
    public void OnGet(int key1, int key2)
    {
        Parm1 = key1;
        Parm2 = key2;
    }
}

