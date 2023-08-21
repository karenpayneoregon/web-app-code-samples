using System.Text.Json;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using HoursApplication.Classes;
using HoursApplication.ExtensiionMethods;
using HoursApplication.Models;
using HoursApplication.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;


#pragma warning disable CS8618

namespace HoursApplication.Pages;


public class IndexModel : PageModel
{

    [ViewData]
    public string Title { get; set; }

    public TimeIncrement SelectedTimeIncrement { get; set; }

    [BindProperty]
    public TimesContainer Container { get; set; }

    public SelectList StartHoursList { get; set; }
    public SelectList EndHoursList { get; set; }

    private readonly Appsettings _appSettings;

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
        LoadSelects();
    }


    /// <summary>
    /// Send Timespans to About Page if valid
    /// </summary>
    public IActionResult OnPost()
    {

        TimesContainerValidator validator = new();
        ValidationResult? result = validator.Validate(Container);

        if (result.IsValid)
        {
            TimesContainer container = new()
            {
                StartTime = Container.StartTime, 
                EndTime = Container.EndTime
            };

            Log.Information("Model is valid");
    
            return RedirectToPage("About", new
            {
                container = JsonSerializer.Serialize(container, new JsonSerializerOptions
                {
                    WriteIndented = true
                })
            });
        }


        result.AddToModelState(ModelState, nameof(Container));

        result.Errors.ForEach(e => Log.Information(e.ErrorMessage));

        LoadSelects();
  
        // set user start and end time
        var selectedStartHour = StartHoursList.FirstOrDefault(
            x => x.Text == Container.StartTime.FormatAmPm());

        if (selectedStartHour != null)
        {
            selectedStartHour.Selected = true;
        }


        var selectedEndHour = EndHoursList.FirstOrDefault(
            x => x.Text == Container.EndTime.FormatAmPm());

        if (selectedEndHour != null)
        {
            selectedEndHour.Selected = true;
        }

        return Page();

    }

    private void LoadSelects()
    {
        StartHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        StartHoursList.FirstOrDefault()!.Disabled = true;
        EndHoursList = new SelectList(Hours.Choice(SelectedTimeIncrement), "TimeSpan", "Text");
        EndHoursList.FirstOrDefault()!.Disabled = true;
    }
}
