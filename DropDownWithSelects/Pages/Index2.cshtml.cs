using DropDownWithSelects.Classes;
using DropDownWithSelects.Data;
using DropDownWithSelects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Serilog;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DropDownWithSelects.Pages
{
    /// <summary>
    /// This page is for the reader to finish
    /// </summary>
    public class Index2Model : PageModel
    {
        private readonly Context _context;

        private readonly ApplicationFeatures _features;
        public List<SelectListItem> Options { get; set; }
        [BindProperty]
        public int SelectedCategory { get; set; }

        public Index2Model(Context context, IOptionsSnapshot<ApplicationFeatures> features)
        {
            _context = context;
            _features = features.Get(ApplicationFeatures.Index2);

            var selectText = _features.SelectText;

            // or
            //var contactTypes = ReferenceTableOperations.ReadContactTypesForDropDown(contactTypeCount);

        }
        public void OnGet()
        {
        }
    }
}
