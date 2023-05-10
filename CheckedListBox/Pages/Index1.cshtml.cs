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
            LoadStuff();
        }
        public void OnGet() { }

        /// <summary>
        /// TODO
        /// - Create database
        /// - Read/write with EF Core
        /// </summary>
        private void LoadStuff()
        {
            CheckModels = new List<ServiceModel>
            {
                new() {Id = 1,  Name = "Headlights", Checked = true},
                new() {Id = 2,  Name = "Brake Light Switches", Checked = false},
                new() {Id = 3,  Name = "Wiper Switches", Checked = false},
                new() {Id = 4,  Name = "Door Jamb Switches", Checked = true}
            };
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
