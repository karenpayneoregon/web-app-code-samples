using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAJAXNamedHandlersDemo.Repositories;

namespace RazorPagesAJAXNamedHandlersDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public IndexModel(ILocationRepository locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public List<SelectListItem> Continents { get; set; }
        public string SelectedContinent { get; set; }

        public List<SelectListItem> Countries { get; set; }
        public string SelectedCountry { get; set; }

        public void OnGet()
        {
            Continents = _locationRepo.GetContinents()
                                      .Select(x=>new SelectListItem() { Value = x, Text = x })
                                      .ToList();

            SelectedContinent = Continents.First().Value;

            Countries = _locationRepo.GetCountries(SelectedContinent)
                                     .Select(x => new SelectListItem() { Value = x, Text = x })
                                     .ToList();
            SelectedCountry = Countries.First().Value;
        }

        public JsonResult OnGetCountriesFilter(string continent)
        {
            return new JsonResult(_locationRepo.GetCountries(continent));
        }

        public JsonResult OnGetContinentsNamesList()
        {
            return new JsonResult(_locationRepo.GetContinents());
        }
        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
            {
                "Val 1",
                "Val 2",
                "Val 3"
            };
            return new JsonResult(lstString);
        }
    }
}
