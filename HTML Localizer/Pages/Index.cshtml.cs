using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Globoticket.Web.Pages
{
    public class IndexModel : PageModel
    {
        public MessageInfo? Message = null;

        public Dictionary<int, Category> CategoriesWithPrices = new Dictionary<int, Category>() {
            { 1, new Category("Standing", 33.33) },
            { 2, new Category("Upper Level", 44.44) },
            { 3, new Category("Lower Level", 55.55) },
        };

        public void OnPost(DateTime eventdate, int category, int amount)
        {
            var totalAmount = amount * CategoriesWithPrices[category].Price;
            Message = new MessageInfo() {
                NumberTickets = amount,
                PluralSuffix = amount > 1 ? "s" : "",
                TotalAmount = totalAmount,
                DateString = eventdate.ToShortDateString()
            };
        }

        public IActionResult OnGetSetCulture(string cultureName)
        {
            var culture = new RequestCulture(cultureName);
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(culture));

            return RedirectToPage("Index");
        }

        public readonly record struct Category(string Description, double Price);

        public readonly record struct MessageInfo(int NumberTickets, string PluralSuffix, double TotalAmount, string DateString);
    }
}