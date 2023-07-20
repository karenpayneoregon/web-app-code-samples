using System.Text.Json;
using FluentValidation.AspNetCore;
using HoursApplication.Classes;
using HoursApplication.Models;
using HoursApplication.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;

#pragma warning disable CS8618

namespace HoursApplication.Pages;

/// <summary>
/// Sample for working with select/option elements
/// Zero validation on if end time is before start time etc.
/// </summary>
public class IndexModel : PageModel
{

    [ViewData]
    public string Title { get; set; }
    public SelectList StartHoursList { get; set; }
    public SelectList EndHoursList { get; set; }

    private readonly Appsettings _appSettings;

    public TimeIncrement SelectedTimeIncrement { get; set; }

    /// <summary>
    /// Get option for showing hours for <seealso cref="TimeIncrement"/>
    /// </summary>
    public IndexModel(IOptions<Appsettings> appSettings)
    {
        _appSettings = appSettings.Value;
        Title = _appSettings.Title;

        // get increment to use via TimeIncrement enum
        SelectedTimeIncrement = Enum.TryParse<TimeIncrement>(_appSettings.TimeIncrement, true,
            out var selection) ?
            selection :
            TimeIncrement.Hourly;
    }

    public void OnGet()
    {
        // setup start hours
        StartHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        StartHoursList.FirstOrDefault()!.Disabled = true;

        // setup end hours
        EndHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        EndHoursList.FirstOrDefault()!.Disabled = true;
    }


    [BindProperty]
    public TimesContainer Container { get; set; }

    /// <summary>
    /// Send Timespans to About Page if valid
    /// </summary>
    public IActionResult OnPost()
    {

        TimesContainerValidator validator = new TimesContainerValidator();

        var result = validator.Validate(Container);

        if (result.IsValid)
        {
            var container = new TimesContainer() { StartTime = Container.StartTime, EndTime = Container.EndTime };


            return RedirectToPage("About", new
            {
                container = JsonSerializer.Serialize(container, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            });
        }

        // we land here if not valid
        result.AddToModelState(ModelState, nameof(Container));

        StartHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        StartHoursList.FirstOrDefault()!.Disabled = true;

        var selectedStartHour = StartHoursList.FirstOrDefault(x => x.Text == Container.StartTime.FormatAmPm());
        if (selectedStartHour != null)
        {
            selectedStartHour.Selected = true;
        }

        EndHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        EndHoursList.FirstOrDefault()!.Disabled = true;
        var selectedEndHour = EndHoursList.FirstOrDefault(x => x.Text == Container.EndTime.FormatAmPm());
        if (selectedEndHour != null)
        {
            selectedEndHour.Selected = true;
        }

        return Page();

    }
}
