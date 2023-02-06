using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.OutputCaching;
using RazorLibrary.Classes;
using Serilog;
using SerilogCustomLogColors.Classes;

namespace SerilogCustomLogColors.Pages;

//[CustomFilter]
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    [BindProperty]

    public string Message { get; set; }

    //[OutputCache(NoStore = true, Duration = 0)]
    public void OnGet()
    {
        Message = "";
        if (TempData.Count == 1 && TempData.ContainsKey("container"))
        {
            Message = TempData.Get<string>("container");
            TempData.Clear();
        }
    }

    public void OnPost()
    {
        
    }
    public IActionResult OnPostButton1(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton1)}");
        return new RedirectToPageResult("Index");
    }
    
    public IActionResult OnPostButton2(IFormCollection data)
    {
        Log.Information($"Entering {nameof(OnPostButton2)}");
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton3(IFormCollection data)
    {
        Log.Information("{TimeOfDay} {UserName} to working with {title} some number {number}", Howdy.TimeOfDay(), "Karen", "SeriLog", 100);
        return new RedirectToPageResult("Index");
    }

    public IActionResult OnPostButton4(IFormCollection data)
    {
        Log.Information("Is {day} a weekend day? {IsWeekday} ",DateTime.Today.DayOfWeek,  DateTime.Now.IsWeekDay());
        return new RedirectToPageResult("Index");
    }

    #region handlers 
    public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
        if (context.HandlerMethod!.MethodInfo.Name == nameof(OnGet))
        {
            // page
        }
        else if (context.HandlerMethod!.MethodInfo.Name == nameof(OnPostButton1))
        {
            Log.Information($"Entering {nameof(OnPageHandlerSelected)} for {nameof(OnPostButton1)}");
        }
    }

    public override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        Log.Information($"In {nameof(OnPageHandlerExecutionAsync)} for {context.HandlerMethod!.MethodInfo.Name}");

        PageContext pageContext = context.HandlerInstance switch
        {
            Page page => page.PageContext,
            PageModel pageModel => pageModel.PageContext,
            _ => null
        };

        if (pageContext is null) return base.OnPageHandlerExecutionAsync(context, next);

        if (context.HandlerMethod.HttpMethod.StartsWith("Post"))
        {
            TempData.Put("container", $"{context.HandlerMethod!.MethodInfo.Name}");

            Log.Information("From {P1} for {P2}", 
                nameof(OnPageHandlerExecutionAsync), 
                context.HandlerMethod!.MethodInfo.Name);
        }

        return base.OnPageHandlerExecutionAsync(context, next);
    }

    public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        if (context.HandlerMethod!.MethodInfo.Name == nameof(OnPostButton4))
        {
            Log.Information("Redirecting from {name}", nameof(OnPostButton4));
            context.Result = new RedirectResult("OtherPage");
        }
        base.OnPageHandlerExecuting(context);
    } 
    #endregion
}
