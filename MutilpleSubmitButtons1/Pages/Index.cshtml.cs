using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultipleSubmitButtons1.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// Gets or sets the number of sessions requested by the user.
    /// </summary>
    /// <remarks>
    /// The value must be at least 1. If the input is invalid, an error message will be displayed.
    /// </remarks>
    /// <value>
    /// An integer representing the count of sessions. The default value is 0.
    /// </value>
    [BindProperty]
    [Range(1, int.MaxValue, ErrorMessage = "Enter at least 1.")]
    public int CountInput { get; set; }

    public int? SessionCount { get; private set; }
    public string? Program { get; private set; }

    /// <summary>
    /// Gets a dictionary containing the available programs for selection.
    ///   Central dictionary (keys = action, values = display text)
    /// </summary>
    /// <remarks>
    /// The keys in the dictionary represent the program identifiers, and the values are the display names of the programs.
    /// This dictionary is case-insensitive when matching keys.
    /// </remarks>
    public Dictionary<string, string> Programs { get; } = new(StringComparer.OrdinalIgnoreCase)
    {
        { "YogaPostures", "Yoga Postures" },
        { "Meditation", "Kriya and Meditation" },
        { "RestorativeYoga", "Restorative Yoga" }
    };

    public void OnGet() { }

    /// <summary>
    /// Handles the HTTP POST request for the page.
    /// </summary>
    /// <remarks>
    /// This method processes the form submission, validates the input, and determines the action to be performed
    /// based on the submitted form data. It updates the session count and program information accordingly.
    /// </remarks>
    /// <returns>
    /// An <see cref="IActionResult"/> that represents the result of the operation. 
    /// Returns the current page if the model state is invalid or if an unknown action is submitted.
    /// </returns>
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var action = Request.Form["action"].ToString();
        SessionCount = CountInput;

        if (Programs.TryGetValue(action, out var programName))
        {
            Program = programName;
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Unknown action.");
            SessionCount = null;
            return Page();
        }

        return Page();
    }
}