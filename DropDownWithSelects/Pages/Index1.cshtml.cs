using DropDownWithSelects.Classes;
using DropDownWithSelects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;

namespace DropDownWithSelects.Pages
{
    public class Index1Model : PageModel
    {

        private readonly ApplicationFeatures _features;

        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int SelectedCategory { get; set; }

        // IOptionsSnapshot picks up appsettings when page loads
        public Index1Model(IOptionsSnapshot<ApplicationFeatures> features)
        {
            _features = features.Get(ApplicationFeatures.Index1);

            var (categoryCount, contactTypeCount) = ReferenceTableOperations.GetTableCount();
            var catsCategoriesList = ReferenceTableOperations.ReadCategoriesForDropDown(categoryCount, _features.SelectText);

            Options = catsCategoriesList.Select(category => new SelectListItem()
            {
                Value = category.CategoryID.ToString(),
                Text = category.CategoryName
            }).ToList();
        }
        public void OnGet()
        {
            // for an application posting place code above here
        }

        public void OnPost(int categoryId)
        {
            if (categoryId == -1)
            {
                Log.Warning("No selection");
                return;
            }

            var categoryName = ReferenceTableOperations.GetCategoryName(categoryId);
            Log.Information("Id {P1} Name {P2}", categoryId, categoryName);
        }
            
    }
}
