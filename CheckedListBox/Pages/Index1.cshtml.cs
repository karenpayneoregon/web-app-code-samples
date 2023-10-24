using CheckedListBox.Classes;
using CheckedListBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

#pragma warning disable CS8618

namespace CheckedListBox.Pages
{
    public class Index1Model : PageModel
    {

        [BindProperty]
        public List<ServiceModel> CheckModels { get; set; }

        public Index1Model()
        {
            Load();
        }
        public void OnGet() { }

        private void Load()
        {

            CheckModels = new List<ServiceModel>();
            foreach (var part in MockedData.PartsList())
            {
                CheckModels.Add(part.Id % 2 == 0
                    ? new ServiceModel() { Id = part.Id, Name = part.Name, Checked = true }
                    : new ServiceModel() { Id = part.Id, Name = part.Name });
            }
        }

        public Task<IActionResult> OnPostResendAsync()
        {
            var checkedItems = CheckModels.Where(x => x.Checked).ToList();

            if (checkedItems.Any())
            {
                Log.Information("Checked items on Index1 post");
                foreach (var model in checkedItems)
                {
                    Log.Information("Id: {Id} Name: {name}", model.Id, model.Name);
                }
            }
            else
            {
                Log.Information("Nothing check for index1 post");
            }


            return Task.FromResult<IActionResult>(RedirectToPage("Index1"));
        }
    }
}
