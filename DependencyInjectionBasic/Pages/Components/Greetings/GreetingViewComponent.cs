using DependencyInjectionBasic.Classes;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionBasic.Pages.Components.Greetings;

[ViewComponent]
public class GreetingViewComponent : ViewComponent
{
    public GreetingViewComponent()
    {
        // we can do what we like here, including using Dependency Injection to bring in services and what not
    }

    public IViewComponentResult Invoke(string name)
    {
        // here we have access to any parameters passed in when we render the ViewComponent (name in this case)
        // so we could do something like this for example...

        // _someService.GetUserDetails(name)
        // although in reality you'd probably want to accept an id rather than a name!

        return View("Default", $"{Howdy.TimeOfDay()} {name}");
    }
}
