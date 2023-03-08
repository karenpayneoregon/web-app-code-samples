using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TelerikSamples1.Classes;


namespace TelerikSamples1.Pages
{
    public class NotificationIndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public JsonResult OnPostRead()
        {
            var list = MockedData.NotificationData();
            Random rnd = new();
            var identifier = rnd.Next(1, list.MaxBy(x => x.Id)!.Id +1);

            return new JsonResult(list.FirstOrDefault(x => x.Id == identifier));
        }
    }
}