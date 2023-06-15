using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebNotifications.Pages;
public class ToastPageModel : PageModel
{
    private readonly ILogger<ToastPageModel> _logger;

    private readonly INotyfService _toastNotification;

    public ToastPageModel(ILogger<ToastPageModel> logger, INotyfService toastNotification)
    {
        _logger = logger;
        _toastNotification = toastNotification;
    }
    public void OnGet()
    {
        _toastNotification.Information("Toast examples.", 2);
    }

    public void OnPostSuccessNotification()
    {
        _toastNotification.Success("Work finished");
    }
    public void OnPostInformationNotification()
    {
        _toastNotification.Information("Time for a break - closes in 6 seconds.", 6);
    }
    public void OnPostWarningNotification()
    {
        _toastNotification.Warning("You have not completed your time-sheet");
    }
    public void OnPostErrorNotification()
    {
        _toastNotification.Error("Operation failed. This message closes in 4 seconds.", 4);
    }
    public void OnPostCustomNotification()
    {
        _toastNotification.Custom("Custom notification - closes in 5 seconds.", 5, "cyan", "fa fa-gear");
    }
}

