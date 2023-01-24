using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleSubmitButtons1.Pages;
public class IndexModel : PageModel
{
    public string Message { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Message = "Response goes here";
    }

    public void OnGet()
    {

    }
    public void OnPostYogaPostures(int sessionCount)
    {
        Message = $"Your request for <span class=\"text-danger fw-bold\">{ sessionCount}</span> sessions in Yoga Posturesis being processed.";
    }

    public void OnPostMeditation(int sessionCount)
    {
        Message = $"Your request for <span class=\"text-danger fw-bold\">{ sessionCount}</span> sessions in Kriya and Meditationis being processed.";
    }


    public void OnPostRestorativeYoga(int sessionCount)
    {
        Message = $"Your request for <span class=\"text-danger fw-bold\">{ sessionCount}</span> sessions in Restorative Yogais being processed.";
    }
}

